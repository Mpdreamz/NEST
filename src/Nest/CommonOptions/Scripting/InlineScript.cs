﻿using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[InterfaceDataContract]
	public interface IInlineScript : IScript
	{
		[DataMember(Name ="source")]
		string Source { get; set; }
	}

	public class InlineScript : ScriptBase, IInlineScript
	{
		public InlineScript(string script) => Source = script;

		public string Source { get; set; }

		public static implicit operator InlineScript(string script) => new InlineScript(script);
	}

	public class InlineScriptDescriptor
		: ScriptDescriptorBase<InlineScriptDescriptor, IInlineScript>, IInlineScript
	{
		public InlineScriptDescriptor() { }

		public InlineScriptDescriptor(string script) => Self.Source = script;

		string IInlineScript.Source { get; set; }

		public InlineScriptDescriptor Source(string script) => Assign(script, (a, v) => a.Source = v);
	}
}
