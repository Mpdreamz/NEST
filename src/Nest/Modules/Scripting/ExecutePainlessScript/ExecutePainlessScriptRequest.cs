using System;
using Newtonsoft.Json;

namespace Nest
{
	/// <summary> The Painless execute API allows an arbitrary script to be executed and a result to be returned. </summary>
	public partial interface IExecutePainlessScriptRequest
	{
		/// <summary> The script to execute </summary>
		[JsonProperty("script")]
		IInlineScript Script { get; set; }

		/// <summary> The context the script should be executed in </summary>
		[JsonProperty("context")]
		string Context { get; set; }

		/// <inheritdoc cref="IPainlessContextSetup"/>
		[JsonProperty("context_setup")]
		IPainlessContextSetup ContextSetup { get; set; }
	}

	/// <inheritdoc cref="IExecutePainlessScriptRequest"/>
	public partial class ExecutePainlessScriptRequest
	{
		/// <inheritdoc cref="IExecutePainlessScriptRequest.Script"/>
		public IInlineScript Script { get; set; }
		/// <inheritdoc cref="IExecutePainlessScriptRequest.Context"/>
		public string Context { get; set; }
		/// <inheritdoc cref="IExecutePainlessScriptRequest.ContextSetup"/>
		public IPainlessContextSetup ContextSetup { get; set; }
	}

	/// <inheritdoc cref="IExecutePainlessScriptRequest"/>
	[DescriptorFor("ScriptsPainlessExecute")]
	public partial class ExecutePainlessScriptDescriptor
	{
		IInlineScript IExecutePainlessScriptRequest.Script { get; set; }
		string IExecutePainlessScriptRequest.Context { get; set; }
		IPainlessContextSetup IExecutePainlessScriptRequest.ContextSetup { get; set; }

		/// <inheritdoc cref="IExecutePainlessScriptRequest.Script"/>
		public ExecutePainlessScriptDescriptor Script(Func<InlineScriptDescriptor, IInlineScript> selector) =>
			Assign(a => a.Script = selector?.Invoke(new InlineScriptDescriptor()));

		/// <inheritdoc cref="IExecutePainlessScriptRequest.ContextSetup"/>
		public ExecutePainlessScriptDescriptor ContextSetup(Func<PainlessContextSetupDescriptor, IPainlessContextSetup> selector) =>
			Assign(a => a.ContextSetup = selector?.Invoke(new PainlessContextSetupDescriptor()));

		/// <inheritdoc cref="IExecutePainlessScriptRequest.Conteext"/>
		public ExecutePainlessScriptDescriptor Context(string context) => Assign(a => a.Context = context);
	}
}
