using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Natural.NUnit.Framework
{
	public class RangeConjunctionAssertion<T> : ConjunctionAssertion
	{
		private ShouldBeAssertion<T> self;

		public RangeConjunctionAssertion(ShouldBeAssertion<T> self)
			: base(self)
		{
			// TODO: Complete member initialization
			this.self = self;
		}

		public static ConjunctionAssertion operator <(RangeConjunctionAssertion<T> actual, T expected)
		{
			return null;
		}

		public static ConjunctionAssertion operator >(RangeConjunctionAssertion<T> actual, T expected)
		{
			return null;
		}
	}
}
