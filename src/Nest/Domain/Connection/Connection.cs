﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nest.Domain.Connection;

namespace Nest
{
	public class Connection : IConnection
	{
		const int BUFFER_SIZE = 1024;

		protected IConnectionSettings _ConnectionSettings { get; set; }
		private Semaphore _ResourceLock;
		private readonly bool _enableTrace;

		public Connection(IConnectionSettings settings)
		{
			if (settings == null)
				throw new ArgumentNullException("settings");

			this._ConnectionSettings = settings;
			var semaphore = Math.Max(1, settings.MaximumAsyncConnections);
			this._ResourceLock = new Semaphore(semaphore, semaphore);
			this._enableTrace = settings.TraceEnabled;
		}

		public ConnectionStatus GetSync(string path)
		{
			return this.HeaderOnlyRequest(path, "GET");
		}
		public ConnectionStatus HeadSync(string path)
		{
			return this.HeaderOnlyRequest(path, "HEAD");
		}

		public ConnectionStatus PostSync(string path, string data)
		{
			return this.BodyRequest(path, data, "POST");
		}
		public ConnectionStatus PutSync(string path, string data)
		{
			return this.BodyRequest(path, data, "PUT");
		}
		public ConnectionStatus DeleteSync(string path)
		{
			var connection = this.CreateConnection(path, "DELETE");
			return this.DoSynchronousRequest(connection);
		}
		public ConnectionStatus DeleteSync(string path, string data)
		{
			var connection = this.CreateConnection(path, "DELETE");
			return this.DoSynchronousRequest(connection, data);
		}

		public Task<ConnectionStatus> Get(string path)
		{
			var r = this.CreateConnection(path, "GET");
			return this.DoAsyncRequest(r);
		}
		public Task<ConnectionStatus> Head(string path)
		{
			var r = this.CreateConnection(path, "HEAD");
			return this.DoAsyncRequest(r);
		}
		public Task<ConnectionStatus> Post(string path, string data)
		{
			var r = this.CreateConnection(path, "POST");
			return this.DoAsyncRequest(r, data);

		}
		public Task<ConnectionStatus> Put(string path, string data)
		{
			var r = this.CreateConnection(path, "PUT");
			return this.DoAsyncRequest(r, data);
		}
		public Task<ConnectionStatus> Delete(string path, string data)
		{
			var r = this.CreateConnection(path, "DELETE");
			return this.DoAsyncRequest(r, data);
		}
		public Task<ConnectionStatus> Delete(string path)
		{
			var r = this.CreateConnection(path, "DELETE");
			return this.DoAsyncRequest(r);
		}

		private static void ThreadTimeoutCallback(object state, bool timedOut)
		{
			if (timedOut)
			{
				HttpWebRequest request = state as HttpWebRequest;
				if (request != null)
				{
					request.Abort();
				}
			}
		}

		private ConnectionStatus HeaderOnlyRequest(string path, string method)
		{
			var connection = this.CreateConnection(path, method);
			return this.DoSynchronousRequest(connection);
		}

		private ConnectionStatus BodyRequest(string path, string data, string method)
		{
			var connection = this.CreateConnection(path, method);
			return this.DoSynchronousRequest(connection, data);
		}

		protected virtual HttpWebRequest CreateConnection(string path, string method)
		{

			var myReq = this.CreateWebRequest(path, method);
			this.SetBasicAuthorizationIfNeeded(myReq);
			this.SetProxyIfNeeded(myReq);
			return myReq;
		}

		private void SetProxyIfNeeded(HttpWebRequest myReq)
		{
			//myReq.Proxy = null;
			if (!string.IsNullOrEmpty(this._ConnectionSettings.ProxyAddress))
			{
				var proxy = new WebProxy();
				var uri = new Uri(this._ConnectionSettings.ProxyAddress);
				var credentials = new NetworkCredential(this._ConnectionSettings.ProxyUsername, this._ConnectionSettings.ProxyPassword);
				proxy.Address = uri;
				proxy.Credentials = credentials;
				myReq.Proxy = proxy;
			}
		}

		private void SetBasicAuthorizationIfNeeded(HttpWebRequest myReq)
		{
			var myUri = this._ConnectionSettings.Uri;
			if (myUri != null && !string.IsNullOrEmpty(myUri.UserInfo))
			{
				myReq.Headers["Authorization"] =
					"Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(myUri.UserInfo));
			}
		}

		protected virtual HttpWebRequest CreateWebRequest(string path, string method)
		{
			var url = this._CreateUriString(path);
			
			HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
			myReq.Accept = "application/json";
			myReq.ContentType = "application/json";

			var timeout = this._ConnectionSettings.Timeout;
			myReq.Timeout = timeout; // 1 minute timeout.
			myReq.ReadWriteTimeout = timeout; // 1 minute timeout.
			myReq.Method = method;
			return myReq;
		}

		protected virtual ConnectionStatus DoSynchronousRequest(HttpWebRequest request, string data = null)
		{
			using (var tracer = new ConnectionStatusTracer(this._ConnectionSettings.TraceEnabled))
			{
				ConnectionStatus cs = null;
				if (data != null)
				{
					using (var r = request.GetRequestStream())
					{
						byte[] buffer = Encoding.UTF8.GetBytes(data);
						r.Write(buffer, 0, buffer.Length);
					}
				}
				try
				{
					using (var response = (HttpWebResponse)request.GetResponse())
					using (var responseStream = response.GetResponseStream())
					using (var streamReader = new StreamReader(responseStream))
					{
						string result = streamReader.ReadToEnd();
						cs = new ConnectionStatus(this._ConnectionSettings, result)
						{
							Request = data,
							RequestUrl = request.RequestUri.ToString(),
							RequestMethod = request.Method
						};
						tracer.SetResult(cs);
						return cs;
					}
				}
				catch (WebException webException)
				{
					cs = new ConnectionStatus(this._ConnectionSettings, webException)
					{
						Request = data,
						RequestUrl = request.RequestUri.ToString(),
						RequestMethod = request.Method
					};
					tracer.SetResult(cs);

                    _ConnectionSettings.ConnectionStatusHandler(cs);

					return cs;
				}
			}
				
		}

		protected virtual Task<ConnectionStatus> DoAsyncRequest(HttpWebRequest request, string data = null)
		{
			var tcs = new TaskCompletionSource<ConnectionStatus>();
			if (this._ConnectionSettings.MaximumAsyncConnections <= 0)
				return this.CreateIterateTask(request, data, tcs);

			var timeout = this._ConnectionSettings.Timeout;
			if (!this._ResourceLock.WaitOne(timeout))
			{
				using (var tracer = new ConnectionStatusTracer(this._ConnectionSettings.TraceEnabled))
				{
					var m = "Could not start the operation before the timeout of " + timeout +
						"ms completed while waiting for the semaphore";
					var cs = new ConnectionStatus(this._ConnectionSettings, new TimeoutException(m));
					tcs.SetResult(cs);
					tracer.SetResult(cs);
					return tcs.Task;
				}
			}
			try
			{
				return this.CreateIterateTask(request, data, tcs);
			}
			finally
			{
				this._ResourceLock.Release();
			}
		}

		private Task<ConnectionStatus> CreateIterateTask(HttpWebRequest request, string data, TaskCompletionSource<ConnectionStatus> tcs)
		{
			this.Iterate(this._AsyncSteps(request, tcs, data), tcs);
			return tcs.Task;
		}

		private IEnumerable<Task> _AsyncSteps(HttpWebRequest request, TaskCompletionSource<ConnectionStatus> tcs, string data = null)
		{
			using (var tracer = new ConnectionStatusTracer(this._ConnectionSettings.TraceEnabled))
			{
				var timeout = this._ConnectionSettings.Timeout;

				var state = new ConnectionState { Connection = request };

				if (data != null)
				{
					var getRequestStream = Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null);
					//ThreadPool.RegisterWaitForSingleObject((getRequestStream as IAsyncResult).AsyncWaitHandle, ThreadTimeoutCallback, request, timeout, true);
					yield return getRequestStream;

					var requestStream = getRequestStream.Result;
					try
					{
						byte[] buffer = Encoding.UTF8.GetBytes(data);
						var writeToRequestStream = Task.Factory.FromAsync(requestStream.BeginWrite, requestStream.EndWrite, buffer, 0, buffer.Length, state);
						yield return writeToRequestStream;
					}
					finally
					{
						requestStream.Close();
					}
				}

				// Get the response
				var getResponse = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
				//ThreadPool.RegisterWaitForSingleObject((getResponse as IAsyncResult).AsyncWaitHandle, ThreadTimeoutCallback, request, timeout, true);
				yield return getResponse;

				// Get the response stream
				using (var response = (HttpWebResponse)getResponse.Result)
				using (var responseStream = response.GetResponseStream())
				{
					// Copy all data from the response stream
					var output = new MemoryStream();
					var buffer = new byte[BUFFER_SIZE];
					while (responseStream != null)
					{
						var read = Task<int>.Factory.FromAsync(responseStream.BeginRead, responseStream.EndRead, buffer, 0, BUFFER_SIZE, null);
						yield return read;
						if (read.Result == 0) break;
						output.Write(buffer, 0, read.Result);
					}

					// Decode the data and store the result
					var result = Encoding.UTF8.GetString(output.ToArray());
					var cs = new ConnectionStatus(this._ConnectionSettings, result) { Request = data, RequestUrl = request.RequestUri.ToString(), RequestMethod = request.Method };
					tcs.TrySetResult(cs);
					tracer.SetResult(cs);
					_ConnectionSettings.ConnectionStatusHandler(cs);
				}
				yield break;
			}

		}

		public void Iterate(IEnumerable<Task> asyncIterator, TaskCompletionSource<ConnectionStatus> tcs)
		{
			var enumerator = asyncIterator.GetEnumerator();
			Action<Task> recursiveBody = null;
			recursiveBody = completedTask =>
			{
				if (completedTask != null && completedTask.IsFaulted)
				{
					//none of the individual steps in _AsyncSteps run in parallel for 1 request
					//as this would be impossible we can assume Aggregate Exception.InnerException
					var exception = completedTask.Exception.InnerException;

					//cleanly exit from exceptions in stages if the exception is a webexception
					if (exception is WebException)
						tcs.SetResult(new ConnectionStatus(this._ConnectionSettings, exception));
					else
						tcs.TrySetException(exception);
					enumerator.Dispose();
				}
				else if (enumerator.MoveNext())
				{
					enumerator.Current.ContinueWith(recursiveBody, TaskContinuationOptions.ExecuteSynchronously);
				}
				else enumerator.Dispose();
			};
			recursiveBody(null);
		}

		private Uri _CreateUriString(string path)
		{
            var s = this._ConnectionSettings;
			
				
			if (s.QueryStringParameters != null)
			{
				var tempUri = new Uri(s.Uri, path);
				var qs = s.QueryStringParameters.ToQueryString(tempUri.Query.IsNullOrEmpty() ? "?" : "&");
				path += qs;
			}
			path = this._ConnectionSettings.DontDoubleEscapePathDotsAndSlashes ? path : path.Replace("%2F", "%252F");
			var uri = new Uri(s.Uri, path);
		
			//WebRequest.Create will replace %2F with / 
			//this is a 'security feature'
			//see http://mikehadlow.blogspot.nl/2011/08/how-to-stop-systemuri-un-escaping.html
			//and http://msdn.microsoft.com/en-us/library/ee656542%28v=vs.100%29.aspx
			//NEST will by default double escape these so that if nest is the only way you talk to elasticsearch
			//it won't barf.
			//If you manually set the config settings to NOT forefully unescape dots and slashes be sure to call 
			//.SetDontDoubleEscapePathDotsAndSlashes() on the connection settings.
			//return );
			//
			return uri;
		}

	}
}
