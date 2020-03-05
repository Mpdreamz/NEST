using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Analysis.Tokenizers
{
	public class LetterTokenizerPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenizers/letter-tokenizer.asciidoc:13")]
		public void Line13()
		{
			// tag::76448aaaaa2c352bb6e09d2f83a3fbb3[]
			var response0 = new SearchResponse<object>();
			// end::76448aaaaa2c352bb6e09d2f83a3fbb3[]

			response0.MatchesExample(@"POST _analyze
			{
			  ""tokenizer"": ""letter"",
			  ""text"": ""The 2 QUICK Brown-Foxes jumped over the lazy dog's bone.""
			}");
		}
	}
}