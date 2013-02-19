---
template: layout.jade
title: Connecting
menusection: concepts
menuitem: writing-queries
---

# Writing Queries
One of the most important things to grasp using Nest is how to write queries. Nest offers you several possibilities. By the way all examples on this page assume being wrapped in

    var result = client.Search<ElasticSearchProject>(s=>s
        .From(0)
        .Size(10)
        ///EXAMPLE HERE
    );

## Raw strings
Although not preffered by me personally many folks like to build their own json strings and just pass that along.

    .QueryRaw("\"match_all\" : { }")
    .FilterRaw("\"match_all\" : { }")

Nest does not modify this in anyway and just writes this straight into the json output. 

## Query DSL
The preffered way to write queries since it gives you alot of cool feautures.

### Lambda expressions
    .Query(q=>q
        .Term(p=>p.Name, "NEST")
    )

Here you'll see we can use expressions to adres properties in a type safe matter. This also works for `IEnumerable` types i.e

    .Query(q=>q
        .Term(p=>p.Followers.First().FirstName, "NEST")
    )

Because these property lookups are expressions you dont have to do any null checks. The previous would expand to the `followers.firstName` property name. 

Of course if you need to pass the property name as string Nest will allow you to do so.

    .Query(q=>q
        .Term("followers.firstName", "martijn")
    )

### Static query/filter generator. 
Sometimes you'll need to resuse a filter or query often. To aid with this you can also write queries like this:

    var termQuery = Query<ElasticSearchProject>
                .Term(p=>p.Followers.First().FirstName, "martijn")
    ...
    .Query(q=>q
        .Bool(bq=>bq
            .Must(
                mq=>mq.MatchAll()
                , termQuery
            )
        )
    )

similarly `Filter<T>.[Filter]()` methods exist for filters.

### Boolean queries 
As can be seen in the previous example writing out boolean queries can turn into a really tedious and verbose effort. Luckily Nest supports bitwise operators and so we can rewrite the previous as such:

    .Query(q=>q.MatchAll() && termQuery)

Note how we are mixing and matching the lambda and static queries here

Similary an `OR` looks like this

    .Query(q=>q
        q.Term("name", "Nest")
        || q.Term("name", "Elastica")
    ) 

`NOT`'s are also supported
    
    .Query(q=>q
        q.Term("language", "php")
        && !q.Term("name", "Elastica")
    )

This will query for all the php clients except `Elastica`

You can mix and match this to any complexity until it satisfies your query requirements.

    .Query(q=>q
        (q.Term("language", "php")
            && !q.Term("name", "Elastica")
        )
        ||
        q.Term("name", "Nest")
    )

will query all php clients except elastica or where the name equals Nest.

#### Clean output support
Normally writing three boolean must clauses looks like this (psuedo code)

    must
        clause1
        clause2
        clause3

A naive implemenation of the bitwise operators would make all the queries sent to elasticsearch look like

    must
        must
            clause1
            clause2
        clause3

This degrades rather rapidly so and makes inspecting generated queries quite a chore. Nest does it's best to detect these cases and always write them in the first clean form.

## Conditionless queries

Writing complex boolean queries is one thing but more often then not you'll want to make decisions on how to query based on user input. 

    public class UserInput
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int? LOC { get; set; }
    }

and then

    .Query(q=> {
            QueryDescriptor<ElasticSearch> query = null;
            if (!string.IsNullOrEmpty(userInput.Name))
                query &= q.Term(p=>p.Name, userInput.Name);
            if (!string.IsNullOrEmpty(userInput.FirstName))
                query &= q
                    .Term("followers.firstName", userInput.FirstName);
            if (userInput.LOC.HasValue)
                query &= q.Range(r=>r.OnField(p=>p.Loc).From(userInput.Loc.Value))
            return query;
        })

This again turns tedious and verbose rather quickly too. Therefor nest allows you to write the previous query as:

    .Query(q=>
        q.Term(p=>p.Name, userInput.Name);
        && q.Term("followers.firstName", userInput.FirstName)
        && q.Range(r=>r.OnField(p=>p.Loc).From(userInput.Loc))
    )

If any of the queries would result in an empty query they won't be sent to elasticsearch. 

So if all the terms are null (or empty string) on `userInput` except `userInput.Loc` it wouldn't even wrap the range query in a boolean query but just issue a plain range query. 

If all of them empty it will result in a `match_all` query. 

This conditionless behavior is turned on by default but can be turned of like so:

     var result = client.Search<ElasticSearchProject>(s=>s
        .From(0)
        .Size(10)
        .Strict() //disable conditionlessqueries by default
        ///EXAMPLE HERE
    );

However queries themselves can opt back in or out.

    .Query(q=>
        q.Strict().Term(p=>p.Name, userInput.Name);
        && q.Term("followers.firstName", userInput.FirstName)
        && q.Strict(false).Range(r=>r.OnField(p=>p.Loc).From(userInput.Loc))
    )

In this example if `userInput.Name` is null or empty it will result in a `DslException`. The range query will use conditionless logic no matter if the SearchDescriptor uses `.Strict()` or not.

Also good to note is that conditionless query logic propagates:

    q.Strict().Term(p=>p.Name, userInput.Name);
    && q.Term("followers.firstName", userInput.FirstName)
    && q.Filtered(fq => fq
        .Query(qff => 
            qff.Terms(p => p.Country, userInput.Countries)
            && qff.Terms(p => p.Loc, userInput.Loc)
        )
    )

If both `userInput.Countries` and `userInput.Loc` are null or empty the entire `filtered` query will be not be issued. 

















