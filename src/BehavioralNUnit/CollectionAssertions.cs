using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BehavioralNUnit
{
	public class CollectionAssertions<T, TItem> : ShouldBeAssertion<T>
		where T : IEnumerable<TItem>
	{
		public CollectionAssertions(T reference) : base(reference)
		{
		}

		public ConjunctionAssertion None()
		{
			throw new NotImplementedException();
		}

		public ConjunctionAssertion None(Expression<Predicate<TItem>> predicate)
		{
			throw new NotImplementedException();
		}

		public ConjunctionAssertion Any()
		{
			throw new NotImplementedException();
		}

		public ConjunctionAssertion Any(Expression<Predicate<TItem>> predicate)
		{
			throw new NotImplementedException();
		}
	}
}
