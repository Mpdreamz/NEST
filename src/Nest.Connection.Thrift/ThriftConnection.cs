using System;
using System.Collections.Generic;
using System.Text;
using Nest.Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Nest;
using System.Threading.Tasks;

namespace Nest.Thrift
{
    // TODO: Cocowalla
    //       Changed from internal to public for performance testing
	public class ThriftConnection : IConnection, IDisposable
	{
		private readonly Rest.Client _client;
		private readonly TProtocol _protocol;
		private readonly TTransport _transport;
		private bool _disposed;

		/// <summary>
		/// 
		/// </summary>
		public ThriftConnection(IConnectionSettings connectionSettings)
		{
			Created = DateTime.Now;
			var tsocket = new TSocket(connectionSettings.Host, connectionSettings.Port);
			_transport = new TBufferedTransport(tsocket, 1024);
			_protocol = new TBinaryProtocol(_transport);
			_client = new Rest.Client(_protocol);
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Created { get; private set; }


		/// <summary>
		/// 
		/// </summary>
		public bool IsOpen
		{
			get { return _transport.IsOpen; }
		}

		#region IConnection Members

		public Task<ConnectionStatus> Get(string path)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.GET;
			restRequest.Uri = path;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ConnectionStatus>(() =>
			{
				var result = GetClient().execute(restRequest);
				return new ConnectionStatus(DecodeStr(result.Body));
			});
		}
		public Task<ConnectionStatus> Head(string path)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.HEAD;
			restRequest.Uri = path;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ConnectionStatus>(()=> 
			{
				var result = GetClient().execute(restRequest);
				return new ConnectionStatus(DecodeStr(result.Body));
			});
		}

		public ConnectionStatus GetSync(string path)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.POST;
			restRequest.Uri = path;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			RestResponse result = GetClient().execute(restRequest);
			return new ConnectionStatus(DecodeStr(result.Body));
		}

		public ConnectionStatus HeadSync(string path)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.HEAD;
			restRequest.Uri = path;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			RestResponse result = GetClient().execute(restRequest);
			return new ConnectionStatus(DecodeStr(result.Body));
		}

		public Task<ConnectionStatus> Post(string path, string data)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.POST;
			restRequest.Uri = path;

			if (!string.IsNullOrEmpty(data))
			{
				restRequest.Body = Encoding.UTF8.GetBytes(data);
			}
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ConnectionStatus>(() =>
			{
				var result = GetClient().execute(restRequest);
				return new ConnectionStatus(DecodeStr(result.Body));
			});
		}
		public Task<ConnectionStatus> Put(string path, string data)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.PUT;
			restRequest.Uri = path;

			if (!string.IsNullOrEmpty(data))
			{
				restRequest.Body = Encoding.UTF8.GetBytes(data);
			}
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ConnectionStatus>(() =>
			{
				var result = GetClient().execute(restRequest);
				return new ConnectionStatus(DecodeStr(result.Body));
			});
		}
		public Task<ConnectionStatus> Delete(string path, string data)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = path;

			if (!string.IsNullOrEmpty(data))
			{
				restRequest.Body = Encoding.UTF8.GetBytes(data);
			}
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ConnectionStatus>(() =>
			{
				var result = GetClient().execute(restRequest);
				return new ConnectionStatus(DecodeStr(result.Body));
			});
		}

		public ConnectionStatus PostSync(string path, string data)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.POST;
			restRequest.Uri = path;

			if (!string.IsNullOrEmpty(data))
			{
				restRequest.Body = Encoding.UTF8.GetBytes(data);
			}
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			RestResponse result = GetClient().execute(restRequest);
			return new ConnectionStatus(DecodeStr(result.Body));
		}
		public ConnectionStatus PutSync(string path, string data)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.PUT;
			restRequest.Uri = path;

			if (!string.IsNullOrEmpty(data))
			{
				restRequest.Body = Encoding.UTF8.GetBytes(data);
			}
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			RestResponse result = GetClient().execute(restRequest);
			return new ConnectionStatus(DecodeStr(result.Body));
		}
		public Task<ConnectionStatus> Delete(string path)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = path;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			return Task.Factory.StartNew<ConnectionStatus>(() =>
			{
				var result = GetClient().execute(restRequest);
				return new ConnectionStatus(DecodeStr(result.Body));
			});
		}

		public ConnectionStatus DeleteSync(string path)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = path;

			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			RestResponse result = GetClient().execute(restRequest);
			return new ConnectionStatus(DecodeStr(result.Body));
		}
		public ConnectionStatus DeleteSync(string path, string data)
		{
			var restRequest = new RestRequest();
			restRequest.Method = Method.DELETE;
			restRequest.Uri = path;

			if (!string.IsNullOrEmpty(data))
			{
				restRequest.Body = Encoding.UTF8.GetBytes(data);
			}
			restRequest.Headers = new Dictionary<string, string>();
			restRequest.Headers.Add("Content-Type", "application/json");
			RestResponse result = GetClient().execute(restRequest);
			return new ConnectionStatus(DecodeStr(result.Body));
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
		/// 
		/// </summary>
		public void Open()
		{
			if (IsOpen)
				return;

			_transport.Open();
		}

		/// <summary>
		/// 
		/// </summary>
		public void Close()
		{
			if (!IsOpen)
				return;

			_transport.Close();
		}

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

			Close();
			_disposed = true;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="Connection"/> is reclaimed by garbage collection.
		/// </summary>
		~ThriftConnection()
		{
			Dispose(false);
		}

		private Rest.Client GetClient()
		{
			Open();
			return _client;
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