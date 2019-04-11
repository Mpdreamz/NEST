﻿using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using HtmlParserSharp;

namespace ApiGenerator.Domain
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class ApiUrl
	{
		private IList<string> _paths;
		private IList<ApiPath> _exposedPaths;
		public IDictionary<string, ApiQueryParameters> Params { get; set; }

		public string Path { get; set; }

		public IEnumerable<string> Paths
		{
			private get => _paths ?? Enumerable.Empty<string>();
			set => _paths = (value ?? Enumerable.Empty<string>()).ToList();
		}

		public IDictionary<string, ApiUrlPart> Parts { get; set; }

		public IEnumerable<ApiPath> ExposedApiPaths
		{
			get
			{
				if (_exposedPaths != null) return _exposedPaths;

				_exposedPaths = Paths.Select(p => new ApiPath(p, Parts)).ToList();
				return _exposedPaths;
			}
		}

		public bool IsPartless => !ExposedApiParts.Any();

		public bool TryGetDocumentApiPath(out ApiPath path)
		{
			path = null;
			if (!IsDocumentApi) return false;

			var mostVerbosePath = _exposedPaths.OrderByDescending(p => p.Parts.Count()).First();
			path = new ApiPath(mostVerbosePath.Path, Parts, mostVerbosePath.Parts);
			return true;
		}


		public IEnumerable<ApiUrlPart> ExposedApiParts => ExposedApiPaths.SelectMany(p => p.Parts).DistinctBy(p => p.Name).ToList();

		private static readonly string[] DocumentApiParts = { "index", "id" };
		public bool IsDocumentApi =>
			ExposedApiParts.Count() == DocumentApiParts.Length
			&& ExposedApiParts.All(p => DocumentApiParts.Contains(p.Name));
	}
}
