﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest;

namespace Nest.Tests.MockData.Domain
{
	[ElasticType(
		Name = "elasticsearchprojects",
		DateDetection = true,
		NumericDetection = true,
		SearchAnalyzer = "standard",
		IndexAnalyzer = "standard",
		DynamicDateFormats = new[] { "dateOptionalTime", "yyyy/MM/dd HH:mm:ss Z||yyyy/MM/dd Z" }
		//TODO Parenttype forces the bulks to specify routing, handle this automagically.
		//,ParentType = "elasticsearchprojects"
	)]
	public class ElasticSearchProject
	{
		public int Id { get; set;  }
		[ElasticProperty(AddSortField=true)]
		public string Name { get; set; }
		public string Version { get; set; }
		[ElasticProperty(
			OmitNorms = true, 
			Index = FieldIndexOption.not_analyzed )]
		public string Country { get; set; }
		public string Content { get; set; }
		[ElasticProperty(Name="loc",AddSortField=true)]
		public int LOC { get; set; }
		public List<Person> Followers { get; set; }

		[ElasticProperty(Type=FieldType.geo_point)]
		public GeoLocation Origin { get; set; }
		public DateTime StartedOn { get; set; }


		//excuse the lame properties i needed some numerics !
		public long LongValue { get; set; }
		public float FloatValue { get; set; }
		public double DoubleValue { get; set; }
		public bool BoolValue { get; set; }
		public List<int> IntValues { get; set; }
		public float[] FloatValues { get; set; }

		[ElasticProperty(NumericType=NumericType.Long)]
		public int StupidIntIWantAsLong { get; set; }

	}
}
