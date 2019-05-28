﻿using System.Collections.Generic;
using System.Linq;
using ApiGenerator.Domain.Code;
using Newtonsoft.Json;

namespace ApiGenerator.Domain.Specification
{
	
	// ReSharper disable once ClassNeverInstantiated.Global
	public class UrlInformation
	{
		public IDictionary<string, QueryParameters> Params { get; set; } = new SortedDictionary<string, QueryParameters>();

		[JsonProperty("paths")]
		private IReadOnlyCollection<string> OriginalPaths { get; set; }

		[JsonProperty("parts")]
		private IDictionary<string, UrlPart> OriginalParts { get; set; }
		
		private List<UrlPath> _paths;
		public IReadOnlyCollection<UrlPath> Paths
		{
			get
			{
				if (_paths != null && _paths.Count > 0) return _paths;

				_paths = OriginalPaths.Select(p => new UrlPath(p, OriginalParts)).ToList();
				return _paths;
			}
		}


		public IReadOnlyCollection<UrlPart> Parts => Paths.SelectMany(p => p.Parts).DistinctBy(p => p.Name).ToList();
		
		public bool IsPartless => !Parts.Any();

		private static readonly string[] DocumentApiParts = { "index", "id" };

		public bool IsDocumentApi => UrlInformation.IsADocumentRoute(Parts);
		
		public static bool IsADocumentRoute(IReadOnlyCollection<UrlPart> parts) =>
			parts.Count() == DocumentApiParts.Length
			&& parts.All(p => DocumentApiParts.Contains(p.Name));


		public bool TryGetDocumentApiPath(out UrlPath path)
		{
			path = null;
			if (!IsDocumentApi) return false;

			var mostVerbosePath = _paths.OrderByDescending(p => p.Parts.Count()).First();
			path = new UrlPath(mostVerbosePath.Path, OriginalParts, mostVerbosePath.Parts);
			return true;
		}

	}
}
