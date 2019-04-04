﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DocGenerator
{
	public static class Program
	{
		static Program()
		{
			string P(string path)
			{
				return path.Replace(@"\", Path.DirectorySeparatorChar.ToString());
			}

			var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
			var globalJson = P(@"..\..\..\global.json");
			if (currentDirectory.Name == "DocGenerator" && currentDirectory.Parent.Name == "CodeGeneration")
			{
				Console.WriteLine("IDE: " + currentDirectory);
				InputDirPath = P(@"..\..\");
				OutputDirPath = P(@"..\..\..\docs");
				BuildOutputPath = P(@"..\..\..\src");
			}
			else
			{
			    globalJson = P(@"..\..\..\..\global.json");
				Console.WriteLine("CMD: " + currentDirectory);
				InputDirPath = P(@"..\..\..\..\src");
				OutputDirPath = P(@"..\..\..\..\docs");
				BuildOutputPath = P(@"..\..\..\..\build\output");
			}

			var globalJsonVersion = string.Join(".", Regex.Matches(File.ReadAllText(globalJson), "\"version\": \"(.*)\"")
										 .Last().Groups
										 .Last().Value
										 .Split(".")
										 .Take(2));
			Console.WriteLine("Using global.json version: " + globalJsonVersion);
			DocVersion = globalJsonVersion;

			var process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					FileName = "git.exe",
					CreateNoWindow = true,
					WorkingDirectory = Environment.CurrentDirectory,
					Arguments = "rev-parse --abbrev-ref HEAD"
				}
			};

			try
			{
				process.Start();
				BranchName = process.StandardOutput.ReadToEnd().Trim();
				process.WaitForExit();
			}
			catch (Exception)
			{
				BranchName = "master";
			}
			finally
			{
				process.Dispose();
			}
		}

		/// <summary>
		/// The branch name to include in generated docs to link back to the original source file
		/// </summary>
		public static string BranchName { get; set; }

		public static string BuildOutputPath { get; }

		/// <summary>
		/// The Elasticsearch documentation version to link to
		/// </summary>
		public static string DocVersion { get; set; }

		public static string InputDirPath { get; }

		public static string OutputDirPath { get; }

		private static int Main(string[] args)
		{
			try
			{
				if (args.Length > 0)
					BranchName = args[0];

				Console.WriteLine($"Using branch name {BranchName} in documentation");

				LitUp.GoAsync(args).Wait();
				return 0;
			}
			catch (AggregateException ae)
			{
				var ex = ae.InnerException ?? ae;
				Console.WriteLine(ex.Message);
				return 1;
			}
		}
	}
}
