﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{

	[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
	public class HighlightFieldDictionary : Dictionary<string, Highlight>
	{
		public HighlightFieldDictionary(IDictionary<string, Highlight> dictionary = null)
		{
			if (dictionary == null)
				return;
			foreach(var kv in dictionary)
			{
				this.Add(kv.Key, kv.Value);
			}
		}
	}

	[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
	public class HighlightDocumentDictionary : Dictionary<string, HighlightFieldDictionary>
	{

	}
}