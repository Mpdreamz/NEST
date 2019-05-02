using System;
using System.Linq;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using Elasticsearch.Net;
using Nest;
using Tests.Benchmarking.Framework;
using Tests.Core.Client;
using Tests.Domain;

namespace Tests.Benchmarking
{
	[BenchmarkConfig]
	public class ExpressionResolverBenchmarkTests
	{

		[GlobalSetup]
		public void Setup() => Client = TestClient.DefaultInMemoryClient;

		public IElasticClient Client { get; set; }

		[Benchmark(Description = "Boxed Expression", OperationsPerInvoke = 1000)]
		public void ResolveBoxedExpressionToString() => ResolveBoxedExpressionToStringImp<Project>(p => p.Suggest.Weight);

		[Benchmark(Description = "Unboxed Expression", OperationsPerInvoke = 1000)]
		public void ResolvedUnboxedExpressionToString() => ResolvedUnboxedExpressionToStringImp<Project, int?>(p => p.Suggest.Weight);

		[Benchmark(Description = "Field Resolver", OperationsPerInvoke = 1000)]
		public void FieldResolver() => FieldResolverImp<Project>(p => p.Suggest.Weight);

		[Benchmark(Description = "Field Resolver Unboxed", OperationsPerInvoke = 1000)]
		public void FieldResolverUnboxed() => FieldResolverUnboxedImp<Project, int?>(p => p.Suggest.Weight);

		private string ResolveBoxedExpressionToStringImp<T>(Expression<Func<T, object>> expression) => expression.ToString();

		private string ResolvedUnboxedExpressionToStringImp<T, TValue>(Expression<Func<T, TValue>> expression) => expression.ToString();

		private string FieldResolverImp<T>(Expression<Func<T, object>> expression) => Client.Infer.Field(expression);

		private string FieldResolverUnboxedImp<T, TValue>(Expression<Func<T, TValue>> expression) => Client.Infer.Field(expression);
	}
}
