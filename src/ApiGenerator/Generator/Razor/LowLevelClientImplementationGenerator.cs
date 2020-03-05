using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiGenerator.Configuration;
using ApiGenerator.Domain;
using ApiGenerator.Domain.Code;
using ShellProgressBar;

namespace ApiGenerator.Generator.Razor
{
	public class LowLevelClientImplementationGenerator : RazorGeneratorBase
	{
		public override string Title { get; } = "Elasticsearch.Net client implementation";

		public override async Task Generate(RestApiSpec spec, ProgressBar progressBar)
		{
			// Delete existing files
			foreach (var file in Directory.GetFiles(GeneratorLocations.EsNetFolder, "ElasticLowLevelClient.*.cs"))
				File.Delete(file);

			var view = ViewLocations.LowLevel("Client", "Implementation", "ElasticLowLevelClient.cshtml");
			var target = GeneratorLocations.LowLevel($"ElasticLowLevelClient.{CsharpNames.RootNamespace}.cs");
			await DoRazor(spec, view, target);

			var namespaced = spec.EndpointsPerNamespaceLowLevel.Where(kv => kv.Key != CsharpNames.RootNamespace).ToList();
			var namespacedView = ViewLocations.LowLevel("Client", "Implementation", "ElasticLowLevelClient.Namespace.cshtml");
			await DoRazorDependantFiles(progressBar, namespaced, namespacedView, kv => kv.Key,
				id => GeneratorLocations.LowLevel($"ElasticLowLevelClient.{id}.cs"));
		}
	}
}
