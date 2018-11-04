﻿using System;

namespace Nest
{
	public interface IBulkDeleteOperation<T> : IBulkOperation
		where T : class
	{
		T Document { get; set; }
	}

	public class BulkDeleteOperation<T> : BulkOperationBase, IBulkDeleteOperation<T>
		where T : class
	{
		public BulkDeleteOperation(T document) => Document = document;

		public BulkDeleteOperation(Id id) => Id = id;

		public T Document { get; set; }

		protected override Type ClrType => typeof(T);

		protected override string Operation => "delete";

		protected override object GetBody() => null;

		protected override Id GetIdForOperation(Inferrer inferrer) => Id ?? new Id(Document);
	}

	public class BulkDeleteDescriptor<T> : BulkOperationDescriptorBase<BulkDeleteDescriptor<T>, IBulkDeleteOperation<T>>, IBulkDeleteOperation<T>
		where T : class
	{
		protected override Type BulkOperationClrType => typeof(T);
		protected override string BulkOperationType => "delete";

		T IBulkDeleteOperation<T>.Document { get; set; }

		protected override object GetBulkOperationBody() => null;

		protected override Id GetIdForOperation(Inferrer inferrer) => Self.Id ?? new Id(Self.Document);

		/// <summary>
		/// The object to infer the id off, (if id is not passed using Id())
		/// </summary>
		public BulkDeleteDescriptor<T> Document(T @object) => Assign(a => a.Document = @object);
	}
}
