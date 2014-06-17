﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using Shared.Extensions;

namespace Nest
{
	/// <summary>
	/// Provides a base for descriptors that need to describe a path that contains a
	/// <pre>
	///	{repository}
	/// </pre>
	/// routing value
	/// </summary>
	public class RepositoryPathDescriptor<TDescriptor, TParameters> : BasePathDescriptor<TDescriptor>
		where TDescriptor : RepositoryPathDescriptor<TDescriptor, TParameters> 
		where TParameters : FluentRequestParameters<TParameters>, new()
	{
		internal string _RepositoryName { get; set; }

		/// <summary>
		/// Specify the name of the repository we are targeting
		/// </summary>
		public TDescriptor Repository(string repositoryName)
		{
			this._RepositoryName = repositoryName;
			return (TDescriptor)this;
		}

		internal virtual ElasticsearchPathInfo<TParameters> ToPathInfo(IConnectionSettingsValues settings, TParameters queryString)
		{
			if (this._RepositoryName.IsNullOrEmpty())
				throw new DslException("missing Repository()");

			var pathInfo = base.ToPathInfo(queryString);
			pathInfo.Repository = this._RepositoryName;
			return pathInfo;
		}

	}
}
