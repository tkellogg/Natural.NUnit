﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Natural.NUnit.Framework
{
	/// <typeparam name="T">
	/// Should be an IComparable, but due to some compilation constraints it is not feasible to add
	/// this as a type constraint. The hope is that as long as the user always accesses this via extension
	/// methods they shouldn't ever instantiate an object of this type where T is not an IComparable.
	/// </typeparam>
	public class RangeConjunctionAssertion<T> : ConjunctionAssertion
	{
		private ShouldBeAssertion<T> assertion;
		private T leftHandValue;

		public RangeConjunctionAssertion(ShouldBeAssertion<T> assertion, T leftHandValue)
			: base(assertion)
		{
			this.assertion = assertion;
			this.leftHandValue = leftHandValue;
		}

		protected internal override IEnumerable<Exception> GetErrors()
		{
			return base.GetErrors();
		}

		public static ConjunctionAssertion operator <(RangeConjunctionAssertion<T> actual, T expected)
		{
			if (!(actual.leftHandValue is IComparable) || !(expected is IComparable))
				throw new InvalidOperationException("Expected an IComparable but got " + typeof(T).FullName);

			actual.AddAssertion(() =>
				Assert.Less((IComparable)actual.leftHandValue, (IComparable)expected));

			return new ConjunctionAssertion(actual);
		}

		public static ConjunctionAssertion operator >(RangeConjunctionAssertion<T> actual, T expected)
		{
			if (!(actual.leftHandValue is IComparable) || !(expected is IComparable))
				throw new InvalidOperationException("Expected an IComparable but got " + typeof(T).FullName);

			actual.AddAssertion(() =>
				Assert.Greater((IComparable)actual.leftHandValue, (IComparable)expected));

			return new ConjunctionAssertion(actual);
		}
	}
}
