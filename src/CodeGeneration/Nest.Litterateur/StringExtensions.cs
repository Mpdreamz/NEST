﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;

namespace Nest.Litterateur
{
	public static class StringExtensions
	{
		public static string PascalToHyphen(this string input)
		{
			if (string.IsNullOrEmpty(input)) return string.Empty;

			return Regex.Replace(
				Regex.Replace(
					Regex.Replace(input, @"([A-Z]+)([A-Z][a-z])", "$1-$2"), @"([a-z\d])([A-Z])", "$1-$2")
				, @"[-\s]", "-").TrimEnd('-').ToLower();
		}

		public static string TrimEnd(this string input, string trim)
		{
			if (string.IsNullOrEmpty(input)) return string.Empty;

			return input.EndsWith(trim, StringComparison.OrdinalIgnoreCase)
				? input.Substring(0, input.Length - trim.Length)
				: input;
		}

		public static string RemoveLeadingAndTrailingMultiLineComments(this string input)
		{
			var match = Regex.Match(input, @"^(?<value>[ \t]*\/\*)");

			if (match.Success)
			{
				input = input.Substring(match.Groups["value"].Value.Length);
			}

			match = Regex.Match(input, @"(?<value>\*\/[ \t]*)$");

			if (match.Success)
			{
				input = input.Substring(0, input.Length - match.Groups["value"].Value.Length);
			}

			return input;
		}

		public static string RemoveLeadingSpacesAndAsterisk(this string input)
		{
			var match = Regex.Match(input, @"^(?<value>[ \t]*\*\s?).*");

			if (match.Success)
			{
				input = input.Substring(match.Groups["value"].Value.Length);
			}

			return input;
		}

		public static string RemoveNumberOfLeadingTabsAfterNewline(this string input, int numberOfTabs)
		{
			return Regex.Replace(input, $"(?<tabs>[\n|\r\n]+\t{{{numberOfTabs}}})", m => m.Value.Replace("\t", string.Empty));
		}

		public static string[] SplitOnNewLines(this string input, StringSplitOptions options)
		{
			return input.Split(new[] { "\r\n", "\n" }, options);
		}

#if !DOTNETCORE
		// TODO: Hack of replacements for now. Resolved by referencing tests assembly when building compilation unit, but might
		// want to put doc generation at same directory level as Tests to reference project directly.
		private static Dictionary<string, string> Substitutions = new Dictionary<string, string>
		{
			{ "FixedDate", "new DateTime(2015, 06, 06, 12, 01, 02, 123)" },
			{ "FirstNameToFind", "\"pierce\"" },
			{ "Project.Projects.First().Suggest.Context.Values.SelectMany(v => v).First()", "\"red\"" },
			{ "Project.Instance.Name", "\"Durgan LLC\"" },
			{ "Project.InstanceAnonymous", "new {name = \"Koch, Collier and Mohr\", state = \"BellyUp\",startedOn = " +
			                               "\"2015-01-01T00:00:00\",lastActivity = \"0001-01-01T00:00:00\",leadDeveloper = " +
			                               "new { gender = \"Male\", id = 0, firstName = \"Martijn\", lastName = \"Laarman\" }," +
										   "location = new { lat = 42.1523, lon = -80.321 }}" },
		}; 

		public static bool TryGetJsonForAnonymousType(this string anonymousTypeString, out string json)
		{
			json = null;

			foreach (var substitution in Substitutions)
			{
				anonymousTypeString = anonymousTypeString.Replace(substitution.Key, substitution.Value);
			}

			var text =
				$@"
					using System;
                    using System.Collections.Generic; 
					using Newtonsoft.Json; 
					using Newtonsoft.Json.Linq;

					namespace Temporary
					{{
						public class Json 
						{{
							public string Write()
							{{
								var o = {anonymousTypeString};
								var json = JsonConvert.SerializeObject(o, Formatting.Indented);
								return json;
							}}
						}}
					}}";

			var syntaxTree = CSharpSyntaxTree.ParseText(text);
			var assemblyName = Path.GetRandomFileName();
			var references = new MetadataReference[]
			{
				MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(typeof(JsonConvert).GetTypeInfo().Assembly.Location),
			};

			var compilation =
				CSharpCompilation.Create(
					assemblyName,
					new[] { syntaxTree },
					references,
					new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

			using (var ms = new MemoryStream())
			{
				var result = compilation.Emit(ms);

				if (!result.Success)
				{
					var failures = result.Diagnostics.Where(diagnostic =>
						diagnostic.IsWarningAsError ||
						diagnostic.Severity == DiagnosticSeverity.Error);

					var builder = new StringBuilder();
					foreach (var diagnostic in failures)
					{
						builder.AppendLine($"{diagnostic.Id}: {diagnostic.GetMessage()}");
					}

					Console.Error.WriteLine(builder.ToString());
					return false;
				}

				ms.Seek(0, SeekOrigin.Begin);

				var assembly = Assembly.Load(ms.ToArray());
				var type = assembly.GetType("Temporary.Json");
				var obj = Activator.CreateInstance(type);

				var output = type.InvokeMember("Write",
					BindingFlags.Default | BindingFlags.InvokeMethod,
					null,
					obj,
					new object[] { });

				json = output.ToString();
				return true;
			}
		}
#endif
	}
}