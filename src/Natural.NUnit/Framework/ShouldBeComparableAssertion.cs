using System;
using NUnit.Framework;

namespace Natural.NUnit.Framework
{
	public class ShouldBeComparableAssertion<T> : ShouldBeAssertion<T>
		where T : IComparable
	{
		public ShouldBeComparableAssertion(T reference) : base(reference)
		{
		}

		public static ConjunctionAssertion operator <(ShouldBeComparableAssertion<T> self, T other)
		{
			self.AddAssertion(() => Assert.Less(self.Reference, other));
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator >(ShouldBeComparableAssertion<T> self, T other)
		{
			self.AddAssertion(() => Assert.Greater(self.Reference, other));
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator <=(ShouldBeComparableAssertion<T> self, T other)
		{
			self.AddAssertion(() => Assert.LessOrEqual(self.Reference, other));
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator >=(ShouldBeComparableAssertion<T> self, T other)
		{
			self.AddAssertion(() => Assert.GreaterOrEqual(self.Reference, other));
			return new ConjunctionAssertion(self);
		}

		#region opposite direction
		public static RangeConjunctionAssertion<T> operator <(T other, ShouldBeComparableAssertion<T> self)
		{
			self.AddAssertion(() => Assert.Less(other, self.Reference));
			return new RangeConjunctionAssertion<T>(self, self.Reference);
		}

		public static RangeConjunctionAssertion<T> operator >(T other, ShouldBeComparableAssertion<T> self)
		{
			self.AddAssertion(() => Assert.Greater(other, self.Reference));
			return new RangeConjunctionAssertion<T>(self, self.Reference);
		}

		public static ConjunctionAssertion operator <=(T other, ShouldBeComparableAssertion<T> self)
		{
			self.AddAssertion(() => Assert.LessOrEqual(other, self.Reference));
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator >=(T other, ShouldBeComparableAssertion<T> self)
		{
			self.AddAssertion(() => Assert.GreaterOrEqual(other, self.Reference));
			return new ConjunctionAssertion(self);
		}
		#endregion
	}
}
