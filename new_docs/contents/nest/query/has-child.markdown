---
template: layout.jade
title: Has Child Query
menusection: query
menuitem: has-child
---


# Has Child Query
The has_child filter accepts a query and the child type to run against, and results in parent documents that have child docs matching the query. Here is an example:

	.HasChild<Person>(fz => fz
		.Query(qq=>qq.Term(f=>f.FirstName, "john"))
		.Scope("my_scope")
	)
