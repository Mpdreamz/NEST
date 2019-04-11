﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ApiGenerator.Domain;
using CsQuery.EquationParser.Implementation;
using Newtonsoft.Json.Linq;
using RazorLight;
using ShellProgressBar;

namespace ApiGenerator
{
	public class ApiGenerator
	{
		private static readonly RazorLightEngine Razor = new RazorLightEngineBuilder()
			.UseMemoryCachingProvider()
			.Build();

		public static List<string> Warnings { get; private set; }

		public static void Generate(string downloadBranch, params string[] folders)
		{
			Warnings = new List<string>();
			var spec = CreateRestApiSpecModel(downloadBranch, folders);
			var actions = new Dictionary<Action<RestApiSpec>, string>
			{
				{ GenerateClientInterface, "Client interface" },
				{ GenerateRequestParameters, "Request parameters" },
				{ GenerateDescriptors, "Descriptors" },
				{ GenerateRequests, "Requests" },
				{ GenerateEnums, "Enums" },
				{ GenerateRawClient, "Lowlevel client" },
				{ GenerateRawDispatch, "Dispatch" },
			};

			using (var pbar = new ProgressBar(actions.Count, "Generating code", new ProgressBarOptions { BackgroundColor = ConsoleColor.DarkGray }))
			{
				foreach (var kv in actions)
				{
					pbar.Message = "Generating " + kv.Value;
					kv.Key(spec);
					pbar.Tick("Generated " + kv.Value);
				}
			}

			if (Warnings.Count == 0) return;

			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach (var warning in Warnings.Distinct().OrderBy(w => w))
				Console.WriteLine(warning);
			Console.ResetColor();
		}

		private static RestApiSpec CreateRestApiSpecModel(string downloadBranch, string[] folders)
		{
			var directories = Directory.GetDirectories(CodeConfiguration.RestSpecificationFolder, "*", SearchOption.AllDirectories)
				.Where(f => folders == null || folders.Length == 0 || folders.Contains(new DirectoryInfo(f).Name))
				.ToList();

			var endpoints = new Dictionary<string, ApiEndpoint>();
			var seenFiles = new HashSet<string>();
			using (var pbar = new ProgressBar(directories.Count, $"Listing {directories.Count} directories",
				new ProgressBarOptions { BackgroundColor = ConsoleColor.DarkGray }))
			{
				var folderFiles = directories.Select(dir =>
					Directory.GetFiles(dir)
						.Where(f => f.EndsWith(".json") && !CodeConfiguration.IgnoredApis.Contains(new FileInfo(f).Name))
						.ToList()
				);
				var commonFile = Path.Combine(CodeConfiguration.RestSpecificationFolder, "Core", "_common.json");
				if (!File.Exists(commonFile)) throw new Exception($"Expected to find {commonFile}");

				RestApiSpec.CommonApiQueryParameters = CreateCommonApiQueryParameters(commonFile);

				foreach (var jsonFiles in folderFiles)
				{
					using (var fileProgress = pbar.Spawn(jsonFiles.Count, $"Listing {jsonFiles.Count} files",
						new ProgressBarOptions { ProgressCharacter = '─', BackgroundColor = ConsoleColor.DarkGray }))
					{
						foreach (var file in jsonFiles)
						{
							if (file.EndsWith("_common.json")) continue;
							else if (file.EndsWith(".obsolete.json")) continue;
							else if (file.EndsWith(".patch.json")) continue;
							else if (file.EndsWith(".replace.json")) continue;
							else
							{
								var endpoint = CreateApiEndpoint(file);
								endpoint.Value.FileName = Path.GetFileName(file);
								seenFiles.Add(Path.GetFileNameWithoutExtension(file));
								endpoints.Add(endpoint.Key, endpoint.Value);
							}

							fileProgress.Tick();
						}
					}
					pbar.Tick();
				}
			}
			var wrongMapsApi = CodeConfiguration.ApiNameMapping.Where(k =>!string.IsNullOrWhiteSpace(k.Key) && !seenFiles.Contains(k.Key));
			foreach (var (key, value) in wrongMapsApi)
			{
				var isIgnored = CodeConfiguration.IgnoredApis.Contains($"{value}.json");
				if (isIgnored) Warnings.Add($"{value} uses MapsApi: {key} ignored in ${nameof(CodeConfiguration)}.{nameof(CodeConfiguration.IgnoredApis)}");
				else Warnings.Add($"{value} uses MapsApi: {key} which does not exist");

			}

			return new RestApiSpec { Endpoints = endpoints, Commit = downloadBranch };
		}

		public static string PascalCase(string s)
		{
			var textInfo = new CultureInfo("en-US").TextInfo;
			return textInfo.ToTitleCase(s.ToLowerInvariant()).Replace("_", string.Empty).Replace(".", string.Empty);
		}

		private static KeyValuePair<string, ApiEndpoint> CreateApiEndpoint(string jsonFile)
		{
			var replaceFile = Path.Combine(Path.GetDirectoryName(jsonFile), Path.GetFileNameWithoutExtension(jsonFile)) + ".replace.json";
			if (File.Exists(replaceFile))
			{
				var replaceSpec = JObject.Parse(File.ReadAllText(replaceFile));
				var endpointReplaced = replaceSpec.ToObject<Dictionary<string, ApiEndpoint>>().First();
				endpointReplaced.Value.RestSpecName = endpointReplaced.Key;
				endpointReplaced.Value.CsharpMethodName = CreateMethodName(endpointReplaced.Key);
				return endpointReplaced;
			}

			var officialJsonSpec = JObject.Parse(File.ReadAllText(jsonFile));
			PatchOfficialSpec(officialJsonSpec, jsonFile);
			var endpoint = officialJsonSpec.ToObject<Dictionary<string, ApiEndpoint>>().First();
			endpoint.Value.RestSpecName = endpoint.Key;
			endpoint.Value.CsharpMethodName = CreateMethodName(endpoint.Key);

			PatchUrlParts(jsonFile, endpoint.Value.Url);
			return endpoint;
		}

		private static void PatchUrlParts(string jsonFile, ApiUrl url)
		{
			if (url.IsPartless) return;
			foreach (var kv in url.Parts)
			{
				var required = url.ExposedApiPaths.All(p => p.Path.Contains($"{{{kv.Key}}}"));
				if (kv.Value.Required != required)
					Warnings.Add($"{jsonFile} has part: {kv.Key} listed as {kv.Value.Required} but should be {required}");
				kv.Value.Required = required;
			}
		}

		private static void PatchOfficialSpec(JObject original, string jsonFile)
		{
			var directory = Path.GetDirectoryName(jsonFile);
			var patchFile = Path.Combine(directory,"..", "_Patches", Path.GetFileNameWithoutExtension(jsonFile)) + ".patch.json";
			if (!File.Exists(patchFile)) return;

			var patchedJson = JObject.Parse(File.ReadAllText(patchFile));

			var pathsOverride = patchedJson.SelectToken("*.url.paths");

			original.Merge(patchedJson, new JsonMergeSettings
			{
				MergeArrayHandling = MergeArrayHandling.Union
			});

			if (pathsOverride != null) original.SelectToken("*.url.paths").Replace(pathsOverride);
		}

		private static Dictionary<string, ApiQueryParameters> CreateCommonApiQueryParameters(string jsonFile)
		{
			var json = File.ReadAllText(jsonFile);
			var jobject = JObject.Parse(json);
			var commonParameters = jobject.Property("params").Value.ToObject<Dictionary<string, ApiQueryParameters>>();
			return ApiQueryParametersPatcher.Patch(null, commonParameters, null, false);
		}

		private static string CreateMethodName(string apiEndpointKey) => PascalCase(apiEndpointKey);

		private static string DoRazor(string name, string template, RestApiSpec model)
		{
			var engine = new RazorLightEngineBuilder()
				.AddPrerenderCallbacks(t =>
				{
				}).Build();
			return engine.CompileRenderAsync(name, template, model).GetAwaiter().GetResult();
		}

		private static void GenerateClientInterface(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.EsNetFolder + @"IElasticLowLevelClient.Generated.cs";
			var source = DoRazor(nameof(GenerateClientInterface),
				File.ReadAllText(CodeConfiguration.ViewFolder + @"IElasticLowLevelClient.Generated.cshtml"), model);
			File.WriteAllText(targetFile, source);
		}

		private static void GenerateRawDispatch(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.NestFolder + @"_Generated/_LowLevelDispatch.Generated.cs";
			var source = DoRazor(nameof(GenerateRawDispatch), File.ReadAllText(CodeConfiguration.ViewFolder + @"_LowLevelDispatch.Generated.cshtml"),
				model);
			File.WriteAllText(targetFile, source);
		}

		private static void GenerateRawClient(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.EsNetFolder + @"ElasticLowLevelClient.Generated.cs";
			var source = DoRazor(nameof(GenerateRawClient),
				File.ReadAllText(CodeConfiguration.ViewFolder + @"ElasticLowLevelClient.Generated.cshtml"), model);
			File.WriteAllText(targetFile, source);
		}

		private static void GenerateDescriptors(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.NestFolder + @"_Generated\_Descriptors.Generated.cs";
			var source = DoRazor(nameof(GenerateDescriptors), File.ReadAllText(CodeConfiguration.ViewFolder + @"_Descriptors.Generated.cshtml"),
				model);
			File.WriteAllText(targetFile, source);
		}

		private static void GenerateRequests(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.NestFolder + @"_Generated\_Requests.Generated.cs";
			var source = DoRazor(nameof(GenerateRequests), File.ReadAllText(CodeConfiguration.ViewFolder + @"_Requests.Generated.cshtml"), model);
			File.WriteAllText(targetFile, source);
		}

		private static void GenerateRequestParameters(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.EsNetFolder + @"Domain\RequestParameters\RequestParameters.Generated.cs";
			var source = DoRazor(nameof(GenerateRequestParameters),
				File.ReadAllText(CodeConfiguration.ViewFolder + @"RequestParameters.Generated.cshtml"), model);
			File.WriteAllText(targetFile, source);
		}

		private static void GenerateEnums(RestApiSpec model)
		{
			var targetFile = CodeConfiguration.EsNetFolder + @"Domain\Enums.Generated.cs";
			var source = DoRazor(nameof(GenerateEnums), File.ReadAllText(CodeConfiguration.ViewFolder + @"Enums.Generated.cshtml"), model);
			File.WriteAllText(targetFile, source);
		}
	}
}
