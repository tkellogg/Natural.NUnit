using System;
using NUnit.Framework;

namespace Natural.NUnit.Framework
{
	public class ShouldBeComparableAssertion<T> : ShouldBeAssertion<T>
	{
		public ShouldBeComparableAssertion(T reference) : base(reference)
		{
		}

		private static void AddAssertion(Action<IComparable, IComparable> method, ShouldBeComparableAssertion<T> self, T actual, T expected)
		{
			if (!(actual is IComparable)) throw new ArgumentException("Expected IComparable but got " + typeof(T).FullName);
			if (!(expected is IComparable)) throw new ArgumentException("Expected IComparable but got " + typeof(T).FullName);
			self.AddAssertion(() => method((IComparable)actual, (IComparable)expected));
		}

		public static RangeConjunctionAssertion<T> operator <(ShouldBeComparableAssertion<T> self, T other)
		{
			AddAssertion(Assert.Less, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		public static RangeConjunctionAssertion<T> operator >(ShouldBeComparableAssertion<T> self, T other)
		{
			AddAssertion(Assert.Greater, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		public static RangeConjunctionAssertion<T> operator <=(ShouldBeComparableAssertion<T> self, T other)
		{
			AddAssertion(Assert.LessOrEqual, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		public static RangeConjunctionAssertion<T> operator >=(ShouldBeComparableAssertion<T> self, T other)
		{
			AddAssertion(Assert.GreaterOrEqual, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		#region opposite direction
		public static RangeConjunctionAssertion<T> operator <(T other, ShouldBeComparableAssertion<T> self)
		{
			AddAssertion(Assert.Less, self, other, self.Reference);
			return new RangeConjunctionAssertion<T>(self, self.Reference);
		}

		public static RangeConjunctionAssertion<T> operator >(T other, ShouldBeComparableAssertion<T> self)
		{
			AddAssertion(Assert.Greater, self, other, self.Reference);
			return new RangeConjunctionAssertion<T>(self, self.Reference);
		}

		public static ConjunctionAssertion operator <=(T other, ShouldBeComparableAssertion<T> self)
		{
			AddAssertion(Assert.LessOrEqual, self, other, self.Reference);
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator >=(T other, ShouldBeComparableAssertion<T> self)
		{
			AddAssertion(Assert.GreaterOrEqual, self, other, self.Reference);
			return new ConjunctionAssertion(self);
		}
		#endregion
	}
}
