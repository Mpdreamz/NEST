using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.IndicesApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.IndicesApi
{
	///<summary>
	/// Logically groups all Indices API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Indices"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class IndicesNamespace : NamespacedClientProxy
	{
		internal IndicesNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IAnalyzeRequest"/>
		public AnalyzeResponse Analyze(Func<AnalyzeDescriptor, IAnalyzeRequest> selector = null) => Analyze(selector.InvokeOrDefault(new AnalyzeDescriptor()));
		///<inheritdoc cref = "IAnalyzeRequest"/>
		public Task<AnalyzeResponse> AnalyzeAsync(Func<AnalyzeDescriptor, IAnalyzeRequest> selector = null, CancellationToken ct = default) => AnalyzeAsync(selector.InvokeOrDefault(new AnalyzeDescriptor()), ct);
		///<inheritdoc cref = "IAnalyzeRequest"/>
		public AnalyzeResponse Analyze(IAnalyzeRequest request) => DoRequest<IAnalyzeRequest, AnalyzeResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IAnalyzeRequest"/>
		public Task<AnalyzeResponse> AnalyzeAsync(IAnalyzeRequest request, CancellationToken ct = default) => DoRequestAsync<IAnalyzeRequest, AnalyzeResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClearCacheRequest"/>
		public ClearCacheResponse ClearCache(Indices index = null, Func<ClearCacheDescriptor, IClearCacheRequest> selector = null) => ClearCache(selector.InvokeOrDefault(new ClearCacheDescriptor().Index(index: index)));
		///<inheritdoc cref = "IClearCacheRequest"/>
		public Task<ClearCacheResponse> ClearCacheAsync(Indices index = null, Func<ClearCacheDescriptor, IClearCacheRequest> selector = null, CancellationToken ct = default) => ClearCacheAsync(selector.InvokeOrDefault(new ClearCacheDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IClearCacheRequest"/>
		public ClearCacheResponse ClearCache(IClearCacheRequest request) => DoRequest<IClearCacheRequest, ClearCacheResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClearCacheRequest"/>
		public Task<ClearCacheResponse> ClearCacheAsync(IClearCacheRequest request, CancellationToken ct = default) => DoRequestAsync<IClearCacheRequest, ClearCacheResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICloseIndexRequest"/>
		public CloseIndexResponse Close(Indices index, Func<CloseIndexDescriptor, ICloseIndexRequest> selector = null) => Close(selector.InvokeOrDefault(new CloseIndexDescriptor(index: index)));
		///<inheritdoc cref = "ICloseIndexRequest"/>
		public Task<CloseIndexResponse> CloseAsync(Indices index, Func<CloseIndexDescriptor, ICloseIndexRequest> selector = null, CancellationToken ct = default) => CloseAsync(selector.InvokeOrDefault(new CloseIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "ICloseIndexRequest"/>
		public CloseIndexResponse Close(ICloseIndexRequest request) => DoRequest<ICloseIndexRequest, CloseIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICloseIndexRequest"/>
		public Task<CloseIndexResponse> CloseAsync(ICloseIndexRequest request, CancellationToken ct = default) => DoRequestAsync<ICloseIndexRequest, CloseIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICreateIndexRequest"/>
		public CreateIndexResponse Create(IndexName index, Func<CreateIndexDescriptor, ICreateIndexRequest> selector = null) => Create(selector.InvokeOrDefault(new CreateIndexDescriptor(index: index)));
		///<inheritdoc cref = "ICreateIndexRequest"/>
		public Task<CreateIndexResponse> CreateAsync(IndexName index, Func<CreateIndexDescriptor, ICreateIndexRequest> selector = null, CancellationToken ct = default) => CreateAsync(selector.InvokeOrDefault(new CreateIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "ICreateIndexRequest"/>
		public CreateIndexResponse Create(ICreateIndexRequest request) => DoRequest<ICreateIndexRequest, CreateIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICreateIndexRequest"/>
		public Task<CreateIndexResponse> CreateAsync(ICreateIndexRequest request, CancellationToken ct = default) => DoRequestAsync<ICreateIndexRequest, CreateIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeleteIndexRequest"/>
		public DeleteIndexResponse Delete(Indices index, Func<DeleteIndexDescriptor, IDeleteIndexRequest> selector = null) => Delete(selector.InvokeOrDefault(new DeleteIndexDescriptor(index: index)));
		///<inheritdoc cref = "IDeleteIndexRequest"/>
		public Task<DeleteIndexResponse> DeleteAsync(Indices index, Func<DeleteIndexDescriptor, IDeleteIndexRequest> selector = null, CancellationToken ct = default) => DeleteAsync(selector.InvokeOrDefault(new DeleteIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "IDeleteIndexRequest"/>
		public DeleteIndexResponse Delete(IDeleteIndexRequest request) => DoRequest<IDeleteIndexRequest, DeleteIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteIndexRequest"/>
		public Task<DeleteIndexResponse> DeleteAsync(IDeleteIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteIndexRequest, DeleteIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeleteAliasRequest"/>
		public DeleteAliasResponse DeleteAlias(Indices index, Names name, Func<DeleteAliasDescriptor, IDeleteAliasRequest> selector = null) => DeleteAlias(selector.InvokeOrDefault(new DeleteAliasDescriptor(index: index, name: name)));
		///<inheritdoc cref = "IDeleteAliasRequest"/>
		public Task<DeleteAliasResponse> DeleteAliasAsync(Indices index, Names name, Func<DeleteAliasDescriptor, IDeleteAliasRequest> selector = null, CancellationToken ct = default) => DeleteAliasAsync(selector.InvokeOrDefault(new DeleteAliasDescriptor(index: index, name: name)), ct);
		///<inheritdoc cref = "IDeleteAliasRequest"/>
		public DeleteAliasResponse DeleteAlias(IDeleteAliasRequest request) => DoRequest<IDeleteAliasRequest, DeleteAliasResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteAliasRequest"/>
		public Task<DeleteAliasResponse> DeleteAliasAsync(IDeleteAliasRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteAliasRequest, DeleteAliasResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeleteIndexTemplateRequest"/>
		public DeleteIndexTemplateResponse DeleteTemplate(Name name, Func<DeleteIndexTemplateDescriptor, IDeleteIndexTemplateRequest> selector = null) => DeleteTemplate(selector.InvokeOrDefault(new DeleteIndexTemplateDescriptor(name: name)));
		///<inheritdoc cref = "IDeleteIndexTemplateRequest"/>
		public Task<DeleteIndexTemplateResponse> DeleteTemplateAsync(Name name, Func<DeleteIndexTemplateDescriptor, IDeleteIndexTemplateRequest> selector = null, CancellationToken ct = default) => DeleteTemplateAsync(selector.InvokeOrDefault(new DeleteIndexTemplateDescriptor(name: name)), ct);
		///<inheritdoc cref = "IDeleteIndexTemplateRequest"/>
		public DeleteIndexTemplateResponse DeleteTemplate(IDeleteIndexTemplateRequest request) => DoRequest<IDeleteIndexTemplateRequest, DeleteIndexTemplateResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteIndexTemplateRequest"/>
		public Task<DeleteIndexTemplateResponse> DeleteTemplateAsync(IDeleteIndexTemplateRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteIndexTemplateRequest, DeleteIndexTemplateResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IIndexExistsRequest"/>
		public ExistsResponse Exists(Indices index, Func<IndexExistsDescriptor, IIndexExistsRequest> selector = null) => Exists(selector.InvokeOrDefault(new IndexExistsDescriptor(index: index)));
		///<inheritdoc cref = "IIndexExistsRequest"/>
		public Task<ExistsResponse> ExistsAsync(Indices index, Func<IndexExistsDescriptor, IIndexExistsRequest> selector = null, CancellationToken ct = default) => ExistsAsync(selector.InvokeOrDefault(new IndexExistsDescriptor(index: index)), ct);
		///<inheritdoc cref = "IIndexExistsRequest"/>
		public ExistsResponse Exists(IIndexExistsRequest request) => DoRequest<IIndexExistsRequest, ExistsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IIndexExistsRequest"/>
		public Task<ExistsResponse> ExistsAsync(IIndexExistsRequest request, CancellationToken ct = default) => DoRequestAsync<IIndexExistsRequest, ExistsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IAliasExistsRequest"/>
		public ExistsResponse AliasExists(Names name, Func<AliasExistsDescriptor, IAliasExistsRequest> selector = null) => AliasExists(selector.InvokeOrDefault(new AliasExistsDescriptor(name: name)));
		///<inheritdoc cref = "IAliasExistsRequest"/>
		public Task<ExistsResponse> AliasExistsAsync(Names name, Func<AliasExistsDescriptor, IAliasExistsRequest> selector = null, CancellationToken ct = default) => AliasExistsAsync(selector.InvokeOrDefault(new AliasExistsDescriptor(name: name)), ct);
		///<inheritdoc cref = "IAliasExistsRequest"/>
		public ExistsResponse AliasExists(IAliasExistsRequest request) => DoRequest<IAliasExistsRequest, ExistsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IAliasExistsRequest"/>
		public Task<ExistsResponse> AliasExistsAsync(IAliasExistsRequest request, CancellationToken ct = default) => DoRequestAsync<IAliasExistsRequest, ExistsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IIndexTemplateExistsRequest"/>
		public ExistsResponse TemplateExists(Names name, Func<IndexTemplateExistsDescriptor, IIndexTemplateExistsRequest> selector = null) => TemplateExists(selector.InvokeOrDefault(new IndexTemplateExistsDescriptor(name: name)));
		///<inheritdoc cref = "IIndexTemplateExistsRequest"/>
		public Task<ExistsResponse> TemplateExistsAsync(Names name, Func<IndexTemplateExistsDescriptor, IIndexTemplateExistsRequest> selector = null, CancellationToken ct = default) => TemplateExistsAsync(selector.InvokeOrDefault(new IndexTemplateExistsDescriptor(name: name)), ct);
		///<inheritdoc cref = "IIndexTemplateExistsRequest"/>
		public ExistsResponse TemplateExists(IIndexTemplateExistsRequest request) => DoRequest<IIndexTemplateExistsRequest, ExistsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IIndexTemplateExistsRequest"/>
		public Task<ExistsResponse> TemplateExistsAsync(IIndexTemplateExistsRequest request, CancellationToken ct = default) => DoRequestAsync<IIndexTemplateExistsRequest, ExistsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ITypeExistsRequest"/>
		public ExistsResponse TypeExists(Indices index, Names type, Func<TypeExistsDescriptor, ITypeExistsRequest> selector = null) => TypeExists(selector.InvokeOrDefault(new TypeExistsDescriptor(index: index, type: type)));
		///<inheritdoc cref = "ITypeExistsRequest"/>
		public Task<ExistsResponse> TypeExistsAsync(Indices index, Names type, Func<TypeExistsDescriptor, ITypeExistsRequest> selector = null, CancellationToken ct = default) => TypeExistsAsync(selector.InvokeOrDefault(new TypeExistsDescriptor(index: index, type: type)), ct);
		///<inheritdoc cref = "ITypeExistsRequest"/>
		public ExistsResponse TypeExists(ITypeExistsRequest request) => DoRequest<ITypeExistsRequest, ExistsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ITypeExistsRequest"/>
		public Task<ExistsResponse> TypeExistsAsync(ITypeExistsRequest request, CancellationToken ct = default) => DoRequestAsync<ITypeExistsRequest, ExistsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IFlushRequest"/>
		public FlushResponse Flush(Indices index = null, Func<FlushDescriptor, IFlushRequest> selector = null) => Flush(selector.InvokeOrDefault(new FlushDescriptor().Index(index: index)));
		///<inheritdoc cref = "IFlushRequest"/>
		public Task<FlushResponse> FlushAsync(Indices index = null, Func<FlushDescriptor, IFlushRequest> selector = null, CancellationToken ct = default) => FlushAsync(selector.InvokeOrDefault(new FlushDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IFlushRequest"/>
		public FlushResponse Flush(IFlushRequest request) => DoRequest<IFlushRequest, FlushResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IFlushRequest"/>
		public Task<FlushResponse> FlushAsync(IFlushRequest request, CancellationToken ct = default) => DoRequestAsync<IFlushRequest, FlushResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ISyncedFlushRequest"/>
		public SyncedFlushResponse SyncedFlush(Indices index = null, Func<SyncedFlushDescriptor, ISyncedFlushRequest> selector = null) => SyncedFlush(selector.InvokeOrDefault(new SyncedFlushDescriptor().Index(index: index)));
		///<inheritdoc cref = "ISyncedFlushRequest"/>
		public Task<SyncedFlushResponse> SyncedFlushAsync(Indices index = null, Func<SyncedFlushDescriptor, ISyncedFlushRequest> selector = null, CancellationToken ct = default) => SyncedFlushAsync(selector.InvokeOrDefault(new SyncedFlushDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "ISyncedFlushRequest"/>
		public SyncedFlushResponse SyncedFlush(ISyncedFlushRequest request) => DoRequest<ISyncedFlushRequest, SyncedFlushResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ISyncedFlushRequest"/>
		public Task<SyncedFlushResponse> SyncedFlushAsync(ISyncedFlushRequest request, CancellationToken ct = default) => DoRequestAsync<ISyncedFlushRequest, SyncedFlushResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IForceMergeRequest"/>
		public ForceMergeResponse ForceMerge(Indices index = null, Func<ForceMergeDescriptor, IForceMergeRequest> selector = null) => ForceMerge(selector.InvokeOrDefault(new ForceMergeDescriptor().Index(index: index)));
		///<inheritdoc cref = "IForceMergeRequest"/>
		public Task<ForceMergeResponse> ForceMergeAsync(Indices index = null, Func<ForceMergeDescriptor, IForceMergeRequest> selector = null, CancellationToken ct = default) => ForceMergeAsync(selector.InvokeOrDefault(new ForceMergeDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IForceMergeRequest"/>
		public ForceMergeResponse ForceMerge(IForceMergeRequest request) => DoRequest<IForceMergeRequest, ForceMergeResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IForceMergeRequest"/>
		public Task<ForceMergeResponse> ForceMergeAsync(IForceMergeRequest request, CancellationToken ct = default) => DoRequestAsync<IForceMergeRequest, ForceMergeResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetIndexRequest"/>
		public GetIndexResponse Get(Indices index, Func<GetIndexDescriptor, IGetIndexRequest> selector = null) => Get(selector.InvokeOrDefault(new GetIndexDescriptor(index: index)));
		///<inheritdoc cref = "IGetIndexRequest"/>
		public Task<GetIndexResponse> GetAsync(Indices index, Func<GetIndexDescriptor, IGetIndexRequest> selector = null, CancellationToken ct = default) => GetAsync(selector.InvokeOrDefault(new GetIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "IGetIndexRequest"/>
		public GetIndexResponse Get(IGetIndexRequest request) => DoRequest<IGetIndexRequest, GetIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetIndexRequest"/>
		public Task<GetIndexResponse> GetAsync(IGetIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IGetIndexRequest, GetIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetAliasRequest"/>
		public GetAliasResponse GetAlias(Indices index = null, Func<GetAliasDescriptor, IGetAliasRequest> selector = null) => GetAlias(selector.InvokeOrDefault(new GetAliasDescriptor().Index(index: index)));
		///<inheritdoc cref = "IGetAliasRequest"/>
		public Task<GetAliasResponse> GetAliasAsync(Indices index = null, Func<GetAliasDescriptor, IGetAliasRequest> selector = null, CancellationToken ct = default) => GetAliasAsync(selector.InvokeOrDefault(new GetAliasDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IGetAliasRequest"/>
		public GetAliasResponse GetAlias(IGetAliasRequest request) => DoRequest<IGetAliasRequest, GetAliasResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetAliasRequest"/>
		public Task<GetAliasResponse> GetAliasAsync(IGetAliasRequest request, CancellationToken ct = default) => DoRequestAsync<IGetAliasRequest, GetAliasResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetFieldMappingRequest"/>
		public GetFieldMappingResponse GetFieldMapping<TDocument>(Fields fields, Func<GetFieldMappingDescriptor<TDocument>, IGetFieldMappingRequest> selector = null)
			where TDocument : class => GetFieldMapping(selector.InvokeOrDefault(new GetFieldMappingDescriptor<TDocument>(fields: fields)));
		///<inheritdoc cref = "IGetFieldMappingRequest"/>
		public Task<GetFieldMappingResponse> GetFieldMappingAsync<TDocument>(Fields fields, Func<GetFieldMappingDescriptor<TDocument>, IGetFieldMappingRequest> selector = null, CancellationToken ct = default)
			where TDocument : class => GetFieldMappingAsync(selector.InvokeOrDefault(new GetFieldMappingDescriptor<TDocument>(fields: fields)), ct);
		///<inheritdoc cref = "IGetFieldMappingRequest"/>
		public GetFieldMappingResponse GetFieldMapping(IGetFieldMappingRequest request) => DoRequest<IGetFieldMappingRequest, GetFieldMappingResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetFieldMappingRequest"/>
		public Task<GetFieldMappingResponse> GetFieldMappingAsync(IGetFieldMappingRequest request, CancellationToken ct = default) => DoRequestAsync<IGetFieldMappingRequest, GetFieldMappingResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetMappingRequest"/>
		public GetMappingResponse GetMapping<TDocument>(Func<GetMappingDescriptor<TDocument>, IGetMappingRequest> selector = null)
			where TDocument : class => GetMapping(selector.InvokeOrDefault(new GetMappingDescriptor<TDocument>()));
		///<inheritdoc cref = "IGetMappingRequest"/>
		public Task<GetMappingResponse> GetMappingAsync<TDocument>(Func<GetMappingDescriptor<TDocument>, IGetMappingRequest> selector = null, CancellationToken ct = default)
			where TDocument : class => GetMappingAsync(selector.InvokeOrDefault(new GetMappingDescriptor<TDocument>()), ct);
		///<inheritdoc cref = "IGetMappingRequest"/>
		public GetMappingResponse GetMapping(IGetMappingRequest request) => DoRequest<IGetMappingRequest, GetMappingResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetMappingRequest"/>
		public Task<GetMappingResponse> GetMappingAsync(IGetMappingRequest request, CancellationToken ct = default) => DoRequestAsync<IGetMappingRequest, GetMappingResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetIndexSettingsRequest"/>
		public GetIndexSettingsResponse GetSettings(Indices index = null, Func<GetIndexSettingsDescriptor, IGetIndexSettingsRequest> selector = null) => GetSettings(selector.InvokeOrDefault(new GetIndexSettingsDescriptor().Index(index: index)));
		///<inheritdoc cref = "IGetIndexSettingsRequest"/>
		public Task<GetIndexSettingsResponse> GetSettingsAsync(Indices index = null, Func<GetIndexSettingsDescriptor, IGetIndexSettingsRequest> selector = null, CancellationToken ct = default) => GetSettingsAsync(selector.InvokeOrDefault(new GetIndexSettingsDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IGetIndexSettingsRequest"/>
		public GetIndexSettingsResponse GetSettings(IGetIndexSettingsRequest request) => DoRequest<IGetIndexSettingsRequest, GetIndexSettingsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetIndexSettingsRequest"/>
		public Task<GetIndexSettingsResponse> GetSettingsAsync(IGetIndexSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IGetIndexSettingsRequest, GetIndexSettingsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetIndexTemplateRequest"/>
		public GetIndexTemplateResponse GetTemplate(Names name = null, Func<GetIndexTemplateDescriptor, IGetIndexTemplateRequest> selector = null) => GetTemplate(selector.InvokeOrDefault(new GetIndexTemplateDescriptor().Name(name: name)));
		///<inheritdoc cref = "IGetIndexTemplateRequest"/>
		public Task<GetIndexTemplateResponse> GetTemplateAsync(Names name = null, Func<GetIndexTemplateDescriptor, IGetIndexTemplateRequest> selector = null, CancellationToken ct = default) => GetTemplateAsync(selector.InvokeOrDefault(new GetIndexTemplateDescriptor().Name(name: name)), ct);
		///<inheritdoc cref = "IGetIndexTemplateRequest"/>
		public GetIndexTemplateResponse GetTemplate(IGetIndexTemplateRequest request) => DoRequest<IGetIndexTemplateRequest, GetIndexTemplateResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetIndexTemplateRequest"/>
		public Task<GetIndexTemplateResponse> GetTemplateAsync(IGetIndexTemplateRequest request, CancellationToken ct = default) => DoRequestAsync<IGetIndexTemplateRequest, GetIndexTemplateResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IUpgradeStatusRequest"/>
		public UpgradeStatusResponse UpgradeStatus(Indices index = null, Func<UpgradeStatusDescriptor, IUpgradeStatusRequest> selector = null) => UpgradeStatus(selector.InvokeOrDefault(new UpgradeStatusDescriptor().Index(index: index)));
		///<inheritdoc cref = "IUpgradeStatusRequest"/>
		public Task<UpgradeStatusResponse> UpgradeStatusAsync(Indices index = null, Func<UpgradeStatusDescriptor, IUpgradeStatusRequest> selector = null, CancellationToken ct = default) => UpgradeStatusAsync(selector.InvokeOrDefault(new UpgradeStatusDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IUpgradeStatusRequest"/>
		public UpgradeStatusResponse UpgradeStatus(IUpgradeStatusRequest request) => DoRequest<IUpgradeStatusRequest, UpgradeStatusResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IUpgradeStatusRequest"/>
		public Task<UpgradeStatusResponse> UpgradeStatusAsync(IUpgradeStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IUpgradeStatusRequest, UpgradeStatusResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IOpenIndexRequest"/>
		public OpenIndexResponse Open(Indices index, Func<OpenIndexDescriptor, IOpenIndexRequest> selector = null) => Open(selector.InvokeOrDefault(new OpenIndexDescriptor(index: index)));
		///<inheritdoc cref = "IOpenIndexRequest"/>
		public Task<OpenIndexResponse> OpenAsync(Indices index, Func<OpenIndexDescriptor, IOpenIndexRequest> selector = null, CancellationToken ct = default) => OpenAsync(selector.InvokeOrDefault(new OpenIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "IOpenIndexRequest"/>
		public OpenIndexResponse Open(IOpenIndexRequest request) => DoRequest<IOpenIndexRequest, OpenIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IOpenIndexRequest"/>
		public Task<OpenIndexResponse> OpenAsync(IOpenIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IOpenIndexRequest, OpenIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutAliasRequest"/>
		public PutAliasResponse PutAlias(Indices index, Name name, Func<PutAliasDescriptor, IPutAliasRequest> selector = null) => PutAlias(selector.InvokeOrDefault(new PutAliasDescriptor(index: index, name: name)));
		///<inheritdoc cref = "IPutAliasRequest"/>
		public Task<PutAliasResponse> PutAliasAsync(Indices index, Name name, Func<PutAliasDescriptor, IPutAliasRequest> selector = null, CancellationToken ct = default) => PutAliasAsync(selector.InvokeOrDefault(new PutAliasDescriptor(index: index, name: name)), ct);
		///<inheritdoc cref = "IPutAliasRequest"/>
		public PutAliasResponse PutAlias(IPutAliasRequest request) => DoRequest<IPutAliasRequest, PutAliasResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutAliasRequest"/>
		public Task<PutAliasResponse> PutAliasAsync(IPutAliasRequest request, CancellationToken ct = default) => DoRequestAsync<IPutAliasRequest, PutAliasResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutMappingRequest"/>
		public PutMappingResponse PutMapping<TDocument>(Func<PutMappingDescriptor<TDocument>, IPutMappingRequest> selector)
			where TDocument : class => PutMapping(selector.InvokeOrDefault(new PutMappingDescriptor<TDocument>()));
		///<inheritdoc cref = "IPutMappingRequest"/>
		public Task<PutMappingResponse> PutMappingAsync<TDocument>(Func<PutMappingDescriptor<TDocument>, IPutMappingRequest> selector, CancellationToken ct = default)
			where TDocument : class => PutMappingAsync(selector.InvokeOrDefault(new PutMappingDescriptor<TDocument>()), ct);
		///<inheritdoc cref = "IPutMappingRequest"/>
		public PutMappingResponse PutMapping(IPutMappingRequest request) => DoRequest<IPutMappingRequest, PutMappingResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutMappingRequest"/>
		public Task<PutMappingResponse> PutMappingAsync(IPutMappingRequest request, CancellationToken ct = default) => DoRequestAsync<IPutMappingRequest, PutMappingResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IUpdateIndexSettingsRequest"/>
		public UpdateIndexSettingsResponse UpdateSettings(Indices index, Func<UpdateIndexSettingsDescriptor, IUpdateIndexSettingsRequest> selector) => UpdateSettings(selector.InvokeOrDefault(new UpdateIndexSettingsDescriptor().Index(index: index)));
		///<inheritdoc cref = "IUpdateIndexSettingsRequest"/>
		public Task<UpdateIndexSettingsResponse> UpdateSettingsAsync(Indices index, Func<UpdateIndexSettingsDescriptor, IUpdateIndexSettingsRequest> selector, CancellationToken ct = default) => UpdateSettingsAsync(selector.InvokeOrDefault(new UpdateIndexSettingsDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IUpdateIndexSettingsRequest"/>
		public UpdateIndexSettingsResponse UpdateSettings(IUpdateIndexSettingsRequest request) => DoRequest<IUpdateIndexSettingsRequest, UpdateIndexSettingsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IUpdateIndexSettingsRequest"/>
		public Task<UpdateIndexSettingsResponse> UpdateSettingsAsync(IUpdateIndexSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IUpdateIndexSettingsRequest, UpdateIndexSettingsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutIndexTemplateRequest"/>
		public PutIndexTemplateResponse PutTemplate(Name name, Func<PutIndexTemplateDescriptor, IPutIndexTemplateRequest> selector) => PutTemplate(selector.InvokeOrDefault(new PutIndexTemplateDescriptor(name: name)));
		///<inheritdoc cref = "IPutIndexTemplateRequest"/>
		public Task<PutIndexTemplateResponse> PutTemplateAsync(Name name, Func<PutIndexTemplateDescriptor, IPutIndexTemplateRequest> selector, CancellationToken ct = default) => PutTemplateAsync(selector.InvokeOrDefault(new PutIndexTemplateDescriptor(name: name)), ct);
		///<inheritdoc cref = "IPutIndexTemplateRequest"/>
		public PutIndexTemplateResponse PutTemplate(IPutIndexTemplateRequest request) => DoRequest<IPutIndexTemplateRequest, PutIndexTemplateResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutIndexTemplateRequest"/>
		public Task<PutIndexTemplateResponse> PutTemplateAsync(IPutIndexTemplateRequest request, CancellationToken ct = default) => DoRequestAsync<IPutIndexTemplateRequest, PutIndexTemplateResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IRecoveryStatusRequest"/>
		public RecoveryStatusResponse RecoveryStatus(Indices index = null, Func<RecoveryStatusDescriptor, IRecoveryStatusRequest> selector = null) => RecoveryStatus(selector.InvokeOrDefault(new RecoveryStatusDescriptor().Index(index: index)));
		///<inheritdoc cref = "IRecoveryStatusRequest"/>
		public Task<RecoveryStatusResponse> RecoveryStatusAsync(Indices index = null, Func<RecoveryStatusDescriptor, IRecoveryStatusRequest> selector = null, CancellationToken ct = default) => RecoveryStatusAsync(selector.InvokeOrDefault(new RecoveryStatusDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IRecoveryStatusRequest"/>
		public RecoveryStatusResponse RecoveryStatus(IRecoveryStatusRequest request) => DoRequest<IRecoveryStatusRequest, RecoveryStatusResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IRecoveryStatusRequest"/>
		public Task<RecoveryStatusResponse> RecoveryStatusAsync(IRecoveryStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IRecoveryStatusRequest, RecoveryStatusResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IRefreshRequest"/>
		public RefreshResponse Refresh(Indices index = null, Func<RefreshDescriptor, IRefreshRequest> selector = null) => Refresh(selector.InvokeOrDefault(new RefreshDescriptor().Index(index: index)));
		///<inheritdoc cref = "IRefreshRequest"/>
		public Task<RefreshResponse> RefreshAsync(Indices index = null, Func<RefreshDescriptor, IRefreshRequest> selector = null, CancellationToken ct = default) => RefreshAsync(selector.InvokeOrDefault(new RefreshDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IRefreshRequest"/>
		public RefreshResponse Refresh(IRefreshRequest request) => DoRequest<IRefreshRequest, RefreshResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IRefreshRequest"/>
		public Task<RefreshResponse> RefreshAsync(IRefreshRequest request, CancellationToken ct = default) => DoRequestAsync<IRefreshRequest, RefreshResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IRolloverIndexRequest"/>
		public RolloverIndexResponse Rollover(Name alias, Func<RolloverIndexDescriptor, IRolloverIndexRequest> selector = null) => Rollover(selector.InvokeOrDefault(new RolloverIndexDescriptor(alias: alias)));
		///<inheritdoc cref = "IRolloverIndexRequest"/>
		public Task<RolloverIndexResponse> RolloverAsync(Name alias, Func<RolloverIndexDescriptor, IRolloverIndexRequest> selector = null, CancellationToken ct = default) => RolloverAsync(selector.InvokeOrDefault(new RolloverIndexDescriptor(alias: alias)), ct);
		///<inheritdoc cref = "IRolloverIndexRequest"/>
		public RolloverIndexResponse Rollover(IRolloverIndexRequest request) => DoRequest<IRolloverIndexRequest, RolloverIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IRolloverIndexRequest"/>
		public Task<RolloverIndexResponse> RolloverAsync(IRolloverIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IRolloverIndexRequest, RolloverIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ISegmentsRequest"/>
		public SegmentsResponse Segments(Indices index = null, Func<SegmentsDescriptor, ISegmentsRequest> selector = null) => Segments(selector.InvokeOrDefault(new SegmentsDescriptor().Index(index: index)));
		///<inheritdoc cref = "ISegmentsRequest"/>
		public Task<SegmentsResponse> SegmentsAsync(Indices index = null, Func<SegmentsDescriptor, ISegmentsRequest> selector = null, CancellationToken ct = default) => SegmentsAsync(selector.InvokeOrDefault(new SegmentsDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "ISegmentsRequest"/>
		public SegmentsResponse Segments(ISegmentsRequest request) => DoRequest<ISegmentsRequest, SegmentsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ISegmentsRequest"/>
		public Task<SegmentsResponse> SegmentsAsync(ISegmentsRequest request, CancellationToken ct = default) => DoRequestAsync<ISegmentsRequest, SegmentsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IIndicesShardStoresRequest"/>
		public IndicesShardStoresResponse ShardStores(Indices index = null, Func<IndicesShardStoresDescriptor, IIndicesShardStoresRequest> selector = null) => ShardStores(selector.InvokeOrDefault(new IndicesShardStoresDescriptor().Index(index: index)));
		///<inheritdoc cref = "IIndicesShardStoresRequest"/>
		public Task<IndicesShardStoresResponse> ShardStoresAsync(Indices index = null, Func<IndicesShardStoresDescriptor, IIndicesShardStoresRequest> selector = null, CancellationToken ct = default) => ShardStoresAsync(selector.InvokeOrDefault(new IndicesShardStoresDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IIndicesShardStoresRequest"/>
		public IndicesShardStoresResponse ShardStores(IIndicesShardStoresRequest request) => DoRequest<IIndicesShardStoresRequest, IndicesShardStoresResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IIndicesShardStoresRequest"/>
		public Task<IndicesShardStoresResponse> ShardStoresAsync(IIndicesShardStoresRequest request, CancellationToken ct = default) => DoRequestAsync<IIndicesShardStoresRequest, IndicesShardStoresResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IShrinkIndexRequest"/>
		public ShrinkIndexResponse Shrink(IndexName index, IndexName target, Func<ShrinkIndexDescriptor, IShrinkIndexRequest> selector = null) => Shrink(selector.InvokeOrDefault(new ShrinkIndexDescriptor(index: index, target: target)));
		///<inheritdoc cref = "IShrinkIndexRequest"/>
		public Task<ShrinkIndexResponse> ShrinkAsync(IndexName index, IndexName target, Func<ShrinkIndexDescriptor, IShrinkIndexRequest> selector = null, CancellationToken ct = default) => ShrinkAsync(selector.InvokeOrDefault(new ShrinkIndexDescriptor(index: index, target: target)), ct);
		///<inheritdoc cref = "IShrinkIndexRequest"/>
		public ShrinkIndexResponse Shrink(IShrinkIndexRequest request) => DoRequest<IShrinkIndexRequest, ShrinkIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IShrinkIndexRequest"/>
		public Task<ShrinkIndexResponse> ShrinkAsync(IShrinkIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IShrinkIndexRequest, ShrinkIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ISplitIndexRequest"/>
		public SplitIndexResponse Split(IndexName index, IndexName target, Func<SplitIndexDescriptor, ISplitIndexRequest> selector = null) => Split(selector.InvokeOrDefault(new SplitIndexDescriptor(index: index, target: target)));
		///<inheritdoc cref = "ISplitIndexRequest"/>
		public Task<SplitIndexResponse> SplitAsync(IndexName index, IndexName target, Func<SplitIndexDescriptor, ISplitIndexRequest> selector = null, CancellationToken ct = default) => SplitAsync(selector.InvokeOrDefault(new SplitIndexDescriptor(index: index, target: target)), ct);
		///<inheritdoc cref = "ISplitIndexRequest"/>
		public SplitIndexResponse Split(ISplitIndexRequest request) => DoRequest<ISplitIndexRequest, SplitIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ISplitIndexRequest"/>
		public Task<SplitIndexResponse> SplitAsync(ISplitIndexRequest request, CancellationToken ct = default) => DoRequestAsync<ISplitIndexRequest, SplitIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IIndicesStatsRequest"/>
		public IndicesStatsResponse Stats(Indices index = null, Func<IndicesStatsDescriptor, IIndicesStatsRequest> selector = null) => Stats(selector.InvokeOrDefault(new IndicesStatsDescriptor().Index(index: index)));
		///<inheritdoc cref = "IIndicesStatsRequest"/>
		public Task<IndicesStatsResponse> StatsAsync(Indices index = null, Func<IndicesStatsDescriptor, IIndicesStatsRequest> selector = null, CancellationToken ct = default) => StatsAsync(selector.InvokeOrDefault(new IndicesStatsDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IIndicesStatsRequest"/>
		public IndicesStatsResponse Stats(IIndicesStatsRequest request) => DoRequest<IIndicesStatsRequest, IndicesStatsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IIndicesStatsRequest"/>
		public Task<IndicesStatsResponse> StatsAsync(IIndicesStatsRequest request, CancellationToken ct = default) => DoRequestAsync<IIndicesStatsRequest, IndicesStatsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IBulkAliasRequest"/>
		public BulkAliasResponse BulkAlias(Func<BulkAliasDescriptor, IBulkAliasRequest> selector) => BulkAlias(selector.InvokeOrDefault(new BulkAliasDescriptor()));
		///<inheritdoc cref = "IBulkAliasRequest"/>
		public Task<BulkAliasResponse> BulkAliasAsync(Func<BulkAliasDescriptor, IBulkAliasRequest> selector, CancellationToken ct = default) => BulkAliasAsync(selector.InvokeOrDefault(new BulkAliasDescriptor()), ct);
		///<inheritdoc cref = "IBulkAliasRequest"/>
		public BulkAliasResponse BulkAlias(IBulkAliasRequest request) => DoRequest<IBulkAliasRequest, BulkAliasResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IBulkAliasRequest"/>
		public Task<BulkAliasResponse> BulkAliasAsync(IBulkAliasRequest request, CancellationToken ct = default) => DoRequestAsync<IBulkAliasRequest, BulkAliasResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IUpgradeRequest"/>
		public UpgradeResponse Upgrade(Indices index = null, Func<UpgradeDescriptor, IUpgradeRequest> selector = null) => Upgrade(selector.InvokeOrDefault(new UpgradeDescriptor().Index(index: index)));
		///<inheritdoc cref = "IUpgradeRequest"/>
		public Task<UpgradeResponse> UpgradeAsync(Indices index = null, Func<UpgradeDescriptor, IUpgradeRequest> selector = null, CancellationToken ct = default) => UpgradeAsync(selector.InvokeOrDefault(new UpgradeDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IUpgradeRequest"/>
		public UpgradeResponse Upgrade(IUpgradeRequest request) => DoRequest<IUpgradeRequest, UpgradeResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IUpgradeRequest"/>
		public Task<UpgradeResponse> UpgradeAsync(IUpgradeRequest request, CancellationToken ct = default) => DoRequestAsync<IUpgradeRequest, UpgradeResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IValidateQueryRequest"/>
		public ValidateQueryResponse ValidateQuery<TDocument>(Func<ValidateQueryDescriptor<TDocument>, IValidateQueryRequest> selector = null)
			where TDocument : class => ValidateQuery(selector.InvokeOrDefault(new ValidateQueryDescriptor<TDocument>()));
		///<inheritdoc cref = "IValidateQueryRequest"/>
		public Task<ValidateQueryResponse> ValidateQueryAsync<TDocument>(Func<ValidateQueryDescriptor<TDocument>, IValidateQueryRequest> selector = null, CancellationToken ct = default)
			where TDocument : class => ValidateQueryAsync(selector.InvokeOrDefault(new ValidateQueryDescriptor<TDocument>()), ct);
		///<inheritdoc cref = "IValidateQueryRequest"/>
		public ValidateQueryResponse ValidateQuery(IValidateQueryRequest request) => DoRequest<IValidateQueryRequest, ValidateQueryResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IValidateQueryRequest"/>
		public Task<ValidateQueryResponse> ValidateQueryAsync(IValidateQueryRequest request, CancellationToken ct = default) => DoRequestAsync<IValidateQueryRequest, ValidateQueryResponse>(request, request.RequestParameters, ct);
	}
}