using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Connection.Thrift.Protocol;
using Elasticsearch.Net.Connection.Thrift.Transport;
using Elasticsearch.Net.Providers;

namespace Elasticsearch.Net.Connection.Thrift
{
	public class ThriftConnection : IConnection, IDisposable
	{
		private readonly ConcurrentQueue<Rest.Client> _clients = new ConcurrentQueue<Rest.Client>();
		private readonly Semaphore _resourceLock;
		private readonly int _timeout;
		private readonly int _poolSize;
		private bool _disposed;
		private readonly IConnectionConfigurationValues _connectionSettings;

		public ThriftConnection(IConnectionConfigurationValues connectionSettings)
		{
			this._connectionSettings = connectionSettings;
			this._timeout = connectionSettings.Timeout;
			this._poolSize = Math.Max(1, connectionSettings.MaximumAsyncConnections);

			this._resourceLock = new Semaphore(_poolSize, _poolSize);
			int seed; bool shouldPingHint;
			for (var i = 0; i <= connectionSettings.MaximumAsyncConnections; i++)
			{
				var uri = this._connectionSettings.ConnectionPool.GetNext(null, out seed, out shouldPingHint);
				var host = uri.Host;
				var port = uri.Port;
				var tsocket = new TSocket(host, port);
				var transport = new TBufferedTransport(tsocket, 1024);
				var protocol = new TBinaryProtocol(transport);
				var client = new Rest.Client(protocol);
				_clients.Enqueue(client);
			}
		}

		#region IConnection Members

		public Task<ElasticsearchResponse<T>> Get<T>(Uri uri, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.GET;
			restRequest.Uri = uri;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ElasticsearchResponse<T>>(() =>
			{
				return this.Execute<T>(restRequest, deserializationState);
			});
		}
	
		public Task<ElasticsearchResponse<T>> Head<T>(Uri uri, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.HEAD;
			restRequest.Uri = uri;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ElasticsearchResponse<T>>(()=> 
			{
				return this.Execute<T>(restRequest, deserializationState);
			});
		}

		public ElasticsearchResponse<T> GetSync<T>(Uri uri, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.GET;
			restRequest.Uri = uri;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return this.Execute<T>(restRequest, deserializationState);
		}

		public ElasticsearchResponse<T> HeadSync<T>(Uri uri, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.HEAD;
			restRequest.Uri = uri;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return this.Execute<T>(restRequest, deserializationState);
		}

		public Task<ElasticsearchResponse<T>> Post<T>(Uri uri, byte[] data, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.POST;
			restRequest.Uri = uri;

			restRequest.Body = data;
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ElasticsearchResponse<T>>(() =>
			{
				return this.Execute<T>(restRequest, deserializationState);
			});
		}
		public Task<ElasticsearchResponse<T>> Put<T>(Uri uri, byte[] data, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.PUT;
			restRequest.Uri = uri;

			restRequest.Body = data;
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ElasticsearchResponse<T>>(() =>
			{
				return this.Execute<T>(restRequest, deserializationState);
			});
		}
		public Task<ElasticsearchResponse<T>> Delete<T>(Uri uri, byte[] data, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = uri;

			restRequest.Body = data;
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ElasticsearchResponse<T>>(() =>
			{
				return this.Execute<T>(restRequest, deserializationState);
			});
		}

		public ElasticsearchResponse<T> PostSync<T>(Uri uri, byte[] data, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.POST;
			restRequest.Uri = uri;

			restRequest.Body = data;
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return this.Execute<T>(restRequest, deserializationState);
		}
		public ElasticsearchResponse<T> PutSync<T>(Uri uri, byte[] data, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.PUT;
			restRequest.Uri = uri;

			restRequest.Body = data;
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return this.Execute<T>(restRequest, deserializationState);
		}
		public Task<ElasticsearchResponse<T>> Delete<T>(Uri uri, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = uri;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ElasticsearchResponse<T>>(() =>
			{
				return this.Execute<T>(restRequest, deserializationState);
			});
		}

		public ElasticsearchResponse<T> DeleteSync<T>(Uri uri, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = uri;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return this.Execute<T>(restRequest, deserializationState);
		}
		public ElasticsearchResponse<T> DeleteSync<T>(Uri uri, byte[] data, object deserializationState = null)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = uri;

			restRequest.Body = data;
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return this.Execute<T>(restRequest, deserializationState);
		}

		public bool Ping(Uri uri)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.HEAD;
			restRequest.Uri = uri;
			
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			var r  = this.Execute<object>(restRequest, null); //TODO VoidResponse
			return r.Success;
		}

		public IList<Uri> Sniff(Uri uri)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.GET;
			restRequest.Uri = new Uri(uri,"/_nodes/_all/clear?timeout=" + this._connectionSettings.PingTimeout.GetValueOrDefault(50));

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			var r  = this.Execute<byte[]>(restRequest, null);
			using (var memoryStream = new MemoryStream(r.Response))
			{
				return Sniffer.FromStream(r, memoryStream, this._connectionSettings.Serializer);
			}
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		#endregion

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			foreach (var c in this._clients)
			{
				if (c != null 
					&& c.InputProtocol != null 
					&& c.InputProtocol.Transport != null 
					&& c.InputProtocol.Transport.IsOpen)
					c.InputProtocol.Transport.Close();
			}
			_disposed = true;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="HttpConnection"/> is reclaimed by garbage collection.
		/// </summary>
		~ThriftConnection()
		{
			Dispose(false);
		}



		private ElasticsearchResponse<T> Execute<T>(RestRequest restRequest, object deserializationState)
		{
			//RestResponse result = GetClient().execute(restRequest);
			//
			var method = Enum.GetName(typeof (Method), restRequest.Method);
			var path = restRequest.Uri.ToString();
			var requestData = restRequest.Body;
			if (!this._resourceLock.WaitOne(this._timeout))
			{
				var m = "Could not start the thrift operation before the timeout of " + this._timeout + "ms completed while waiting for the semaphore";
				return ElasticsearchResponse<T>.CreateError(this._connectionSettings, new TimeoutException(m), method, path, requestData);
			}
			try
			{
				Rest.Client client = null;
				if (!this._clients.TryDequeue(out client))
				{
					var m = string.Format("Could dequeue a thrift client from internal socket pool of size {0}", this._poolSize);
					var status = ElasticsearchResponse<T>.CreateError(this._connectionSettings, new Exception(m), method, path, requestData);
					return status;
				}
				try
				{
					if (!client.InputProtocol.Transport.IsOpen)
						client.InputProtocol.Transport.Open();

					var result = client.execute(restRequest);
					if (result.Status == Status.OK || result.Status == Status.CREATED || result.Status == Status.ACCEPTED)
					{
						var response = ElasticsearchResponse<T>.Create(this._connectionSettings, (int)result.Status, method, path, requestData);
						if (typeof(T) == typeof(VoidResponse))
							return response;
						using (var ms = new MemoryStream(result.Body))
						{
							if (this._connectionSettings.KeepRawResponse) 
							{
								response.ResponseRaw = result.Body;
							}
							if (typeof(T) == typeof(string))
								this.SetStringResult(response as ElasticsearchResponse<string>, result.Body);
							else if (typeof(T) == typeof(byte[]))
								this.SetByteResult(response as ElasticsearchResponse<byte[]>, result.Body);
							else 
								response.Response = this._connectionSettings.Serializer.Deserialize<T>(response, ms, deserializationState);
							return response;
						};
					}
					else
					{
						var connectionException = new ConnectionException((int)result.Status);
						return ElasticsearchResponse<T>.CreateError(this._connectionSettings, connectionException, method, path, requestData);
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					//make sure we make the client available again.
					this._clients.Enqueue(client);
				}

			}
			catch (Exception e)
			{
				return ElasticsearchResponse<T>.CreateError(this._connectionSettings, e, method, path, requestData);
			}
			finally
			{
				this._resourceLock.Release();
			}
		}

		private void SetByteResult(ElasticsearchResponse<byte[]> elasticsearchResponse, byte[] body)
		{
			elasticsearchResponse.Response = body;
		}

		private void SetStringResult(ElasticsearchResponse<string> elasticsearchResponse, byte[] body)
		{
			elasticsearchResponse.Response = body.Utf8String();
		}

		public string DecodeStr(byte[] bytes)
		{
			if (bytes != null && bytes.Length > 0)
			{
				return Encoding.UTF8.GetString(bytes);
			}
			return string.Empty;
		}
	}
}