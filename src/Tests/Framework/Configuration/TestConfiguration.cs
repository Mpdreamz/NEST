﻿using System;
using System.IO;
using System.Linq;

namespace Tests.Framework.Configuration
{
	public class TestConfiguration
	{
		public TestMode Mode { get; private set; } = TestMode.Unit;
		public string ElasticsearchVersion { get; private set; } = "2.0.0-rc1";
		public bool ForceReseed { get; private set; }
		public bool DoNotSpawnIfAlreadyRunning { get; private set; }

		public bool RunIntegrationTests => Mode == TestMode.Mixed || Mode == TestMode.Integration;
		public bool RunUnitTests => Mode == TestMode.Mixed || Mode == TestMode.Unit;

		public TestConfiguration(string configurationFile)
		{
			if (!File.Exists(configurationFile)) return;

			var config = File.ReadAllLines(configurationFile)
				.Where(l=>!l.Trim().StartsWith("#"))
				.ToDictionary(l => ConfigName(l), l => ConfigValue(l));

			this.Mode = GetTestMode(config["mode"]);
			this.ElasticsearchVersion = config["elasticsearch_version"];
			this.ForceReseed = bool.Parse(config["force_reseed"]);
			this.DoNotSpawnIfAlreadyRunning = bool.Parse(config["do_not_spawn"]);
		}

		private string ConfigName(string configLine) => Parse(configLine, 0);
		private string ConfigValue(string configLine) => Parse(configLine, 1);
		private string Parse(string configLine, int index) => configLine.Split(':')[index].Trim(' ');
		private TestMode GetTestMode(string mode)
		{
			switch(mode)
			{
				case "unit":
				case "u":
					return TestMode.Unit;
				case "integration":
				case "i":
					return TestMode.Integration;
				case "mixed":
				case "m":
					return TestMode.Mixed;
				default:
					throw new ArgumentException($"Unknown test mode: {mode}");
			}
		}
	}
}
