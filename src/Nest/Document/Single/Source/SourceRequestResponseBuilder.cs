using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public class SourceRequestResponseBuilder<TDocument> : CustomResponseBuilderBase
	{
		public static SourceRequestResponseBuilder<TDocument> Instance { get; } = new SourceRequestResponseBuilder<TDocument>();

		public override object DeserializeResponse(IElasticsearchSerializer builtInSerializer, IApiCallDetails response, Stream stream)
		{
			return response.Success
				? new SourceResponse<TDocument> { Body = builtInSerializer.Deserialize<TDocument>(stream) }
				: new SourceResponse<TDocument>();
		}

		public override async Task<object> DeserializeResponseAsync(IElasticsearchSerializer builtInSerializer, IApiCallDetails response, Stream stream, CancellationToken ctx = default)
		{
			return response.Success
				? new SourceResponse<TDocument> { Body = await builtInSerializer.DeserializeAsync<TDocument>(stream) }
				: new SourceResponse<TDocument>();
		}
	}
}
