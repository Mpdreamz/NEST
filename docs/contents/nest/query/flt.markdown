---
template: layout.jade
title: Fuzzy Like This Query
menusection: query
menuitem: flt
---


# Fuzzy Like This Query
Fuzzy like this query find documents that are “like” provided text by running it against one or more fields.

	.Query(qd=>qd
		.FuzzyLikeThis(fz => fz
			.OnFields(f => f.Name)
			.LikeText("elasticsearcc")
			.PrefixLength(3)
			.MaxQueryTerms(25)
			.IgnoreTermFrequency(true)
			.Boost(1.1)
			.Analyzer("my_analyzer")
		)
	)


