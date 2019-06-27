﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nest
{
	public static partial class ElasticClientExtensions
	{
		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static CatResponse<CatTemplatesRecord> CatTemplates(this IElasticClient client,
			Func<CatTemplatesDescriptor, ICatTemplatesRequest> selector = null
		)
			=> client.Cat.Templates(selector);

		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static CatResponse<CatTemplatesRecord> CatTemplates(this IElasticClient client, ICatTemplatesRequest request)
			=> client.Cat.Templates(request);

		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static Task<CatResponse<CatTemplatesRecord>> CatTemplatesAsync(this IElasticClient client,
			Func<CatTemplatesDescriptor, ICatTemplatesRequest> selector = null,
			CancellationToken ct = default
		)
			=> client.Cat.TemplatesAsync(selector, ct);

		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static Task<CatResponse<CatTemplatesRecord>> CatTemplatesAsync(this IElasticClient client, ICatTemplatesRequest request,
			CancellationToken ct = default
		)
			=> client.Cat.TemplatesAsync(request, ct);
	}
}
