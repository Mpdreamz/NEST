﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using CodeGeneration.YamlTestsRunner.Domain;
using CsQuery;
using CsQuery.ExtensionMethods.Internal;
using FubuCsProjFile;
using ShellProgressBar;
using Xipton.Razor;
using YamlDotNet.Serialization;

namespace CodeGeneration.YamlTestsRunner
{
	using YamlTestSuite = Dictionary<string, object>;
	public static class YamlTestsGenerator
	{
	    private const string _listingUrl = "https://github.com/elasticsearch/elasticsearch/tree/v1.3.2/rest-api-spec/test";
	    private const string _rawUrlPrefix = "https://raw.github.com/elasticsearch/elasticsearch/v1.3.2/rest-api-spec/test/";
	    private const string _testProjectFolder = @"..\..\..\..\..\src\Tests\Elasticsearch.Net.Integration.Yaml\";
	    private const string _rawClientInterface = @"..\..\..\..\..\src\Elasticsearch.Net\IElasticsearchClient.generated.cs";
	    private const string _viewFolder = @"..\..\Views\";
	    private const string _cacheFolder = @"..\..\YamlCache\";

	    private static readonly RazorMachine _razorMachine;
		private static readonly Assembly _assembly;
		public static IEnumerable<string> RawElasticCalls;

		static YamlTestsGenerator()
		{
			_razorMachine = new RazorMachine();
			_assembly = typeof (YamlTestsGenerator).Assembly;
			RegisterView("Do");
			RegisterView("Set");
			RegisterView("IsTrue");
			RegisterView("IsFalse");
			RegisterView("LowerThan");
			RegisterView("GreaterThan");
			RegisterView("Length");
			RegisterView("Match");
			RegisterView("Skip");
			RegisterView("DispatchSteps");
			RegisterView("SetupClass");
			var rawCalls = from l in File.ReadAllLines(_rawClientInterface)
				where Regex.IsMatch(l, @"\tElasticsearchResponse<[^>]+> ")
				select Regex.Replace(l,@"\t\tElasticsearchResponse<[^>]+>", "").Trim();
			RawElasticCalls = rawCalls.ToList();
		}

		private static void RegisterView(string name)
		{
			_razorMachine.RegisterTemplate("~/_MemoryContent/"+name+".cshtml", File.ReadAllText(_viewFolder + name + @".cshtml"));
		}

		public static YamlSpecification GetYamlTestSpecification(bool useCache = false)
		{
			var folders = GetTestFolders(useCache);

			var yamlFiles = new ConcurrentDictionary<string, IList<YamlDefinition>>();
			using (var pbar = new ProgressBar(folders.Count, "Finding all the yaml files"))
			//Parallel.ForEach(folders, (folder) =>
				foreach (var folder in folders)
				{
					var definitions = GetFolderFiles(folder, useCache);
					yamlFiles.TryAdd(folder, definitions);
					pbar.Tick(string.Format("Found {0} yaml test files in {1}", definitions.Count(), folder));
					//});
				}
			return new YamlSpecification
			{
				Definitions = yamlFiles.ToDictionary(k => k.Key, v => v.Value)
			};
		}

		/// <summary>
		/// TODO: these tests contain object definitions that the ToAnonymous barfs on.
		/// We skip them for now but we should fix the generator so that it generates dictionaries
		/// in this case.
		/// NOTE: files must be prefixed with the containing folder since they are not uniquely named
		/// </summary>
		private static string[] SkipTests = new string[]
		{
			"search/40_search_request_template.yaml",
			"search/30_template_query_execution.yaml",
			"percolate/19_nested.yaml",
			"index/60_refresh.yaml",
			"create/60_refresh.yaml",
			"update/60_refresh.yaml",
			"search_shards/10_basic.yaml",
			"template/10_basic.yaml"
		};

		private static IList<YamlDefinition> GetFolderFiles(string folder, bool useCache = false)
		{
			var url = useCache ? LocalUri(folder + ".html") : _listingUrl + "/" + folder;
			var folderHtml = new WebClient().DownloadString(url);
			if (!useCache)
				File.WriteAllText(_cacheFolder + folder + ".html", folderHtml);
			var files = (from a in CQ.Create(folderHtml)[".js-directory-link"]
				let fileName = a.InnerText
				where fileName.EndsWith(".yaml")
				select fileName).ToList();

			var definitions = new ConcurrentBag<YamlDefinition>();
			var i = 0;
			foreach (var file in files)
			{
				++i;

				if (SkipTests.Contains(folder + "/" + file))
					continue;

				var yaml = GetYamlFile(folder, useCache, file);
				var parsed = ParseYaml(yaml).ToList();
				var prefix = Regex.Replace(file, @"^(\d+).*$", "$1");
				var yamlDefinition = new YamlDefinition
				{
					Folder = folder + i,
					FileName = file,
					Contents = yaml,
					Suites = parsed,
					Suffix = prefix
				};
				PatchDefinition(yamlDefinition, folder, file);
				definitions.Add(yamlDefinition);
			}
			return definitions.ToList();
		}

		/// <summary>
		/// Path definition to catch known name clashes for instance
		/// </summary>
		private static void PatchDefinition(YamlDefinition yamlDefinition, string folder, string file)
		{
			if (file == "10_ping.yaml")
				yamlDefinition.Suites.First().Description = "Ping returns true";
			if (file == "55_parent_with_routing.yaml")
				yamlDefinition.Suites.First().Description = "Parent with routing";
			if (file == "10_info.yaml")
				yamlDefinition.Suites.First().Description = "Info returns body";
			if (file == "20_fields_pre_0.90.3.yaml")
				yamlDefinition.Suites.First().Description = "Fields Pre 0.90.3";

			var setupRoutine = yamlDefinition.Suites
				.FirstOrDefault(s => s.Description.Contains("setup"));
			if (setupRoutine != null)
			{
				yamlDefinition.SetupSuite = setupRoutine;
				foreach (var suite in yamlDefinition.Suites)
					suite.HasSetup = true;
				yamlDefinition.Suites = yamlDefinition.Suites.Where(s => !s.Description.Contains("setup"));
			}
		}

		private static IEnumerable<TestSuite> ParseYaml(string yaml)
		{
			var deserializer = new Deserializer();
			var tests = Regex.Split(yaml, @"--- ?\r?\n");
			var r = new List<TestSuite>();
			var i = 0;
			foreach (var test in tests.Where(t=>!t.IsNullOrEmpty()))
			{
				++i;
				using (var tx = new StringReader(test))
				{
					var parsed = deserializer.Deserialize<YamlTestSuite>(tx);
					var suite = TestSuite.CreateFrom(parsed, yaml);
					suite.Description += i;
					r.Add(suite);
				}
			}
			return r;
		}

		private static string GetYamlFile(string folder, bool useCache, string file)
		{
			var folderFile = folder + "/" + file;
			var url = useCache ? LocalUri(folderFile) : _rawUrlPrefix + folderFile;
			var yaml = new WebClient().DownloadString(url);
			if (useCache) 
				return yaml;
			if (!Directory.Exists(_cacheFolder + folder))
				Directory.CreateDirectory(_cacheFolder + folder);

			File.WriteAllText(_cacheFolder + folderFile, yaml);
			return yaml;
		}

		private static List<string> GetTestFolders(bool useCache)
		{
			var url = useCache ? LocalUri("root.html") : _listingUrl;
			var folderListingHtml = new WebClient().DownloadString(url);
			if (!useCache)
			{
				if (!Directory.Exists(_cacheFolder))
					Directory.CreateDirectory(_cacheFolder);

				File.WriteAllText(_cacheFolder + "root.html", folderListingHtml);
			}
			
			var folders = (from a in CQ.Create(folderListingHtml)[".js-directory-link"]
				let folderName = a.InnerText
				where !folderName.EndsWith(".asciidoc")
				select folderName).ToList();
			return folders;
		}

		public static void GenerateProject(YamlSpecification specification)
		{
			var project = CsProjFile.LoadFrom(_testProjectFolder + @"Elasticsearch.Net.Integration.Yaml.csproj");
			var existingYamlTests = project.All<CodeFile>().Where(c=>c.Link != null && c.Link.EndsWith(".yaml.cs"));
			foreach (var c in existingYamlTests)
				project.Remove(c);

			var definitions = specification.Definitions;

			using (var pbar = new ProgressBar(definitions.Count, "Generating Code and project for yaml tests", ConsoleColor.Blue))
			foreach (var kv in specification.Definitions)
			{
				var folder = kv.Key;
				foreach (var d in kv.Value)
				{
					var path = folder + @"\" + d.FileName + ".cs";
					if (!Directory.Exists(_testProjectFolder + folder))
						Directory.CreateDirectory(_testProjectFolder + folder);

					GenerateTestFileFromView(_testProjectFolder + path, d);
					project.Add<CodeFile>(path);
				}
				pbar.Tick();
			}
			project.Save();
		}
		private static string LocalUri(string file)
		{
			var basePath = Path.Combine(Assembly.GetEntryAssembly().Location, @"..\" + _cacheFolder + file);
			var assemblyPath = Path.GetFullPath((new Uri(basePath)).LocalPath);
			var fileUri = new Uri(assemblyPath).AbsoluteUri;
			return fileUri;
		}
		
		public static void GenerateTestFileFromView(string targetFile, YamlDefinition model)
		{
			var source = _razorMachine.Execute(File.ReadAllText(_viewFolder + @"TestSuite.cshtml"), model).ToString();
			File.WriteAllText(targetFile, source);
		}
	}
}
