using System;
using NUnit.Framework;

namespace BehavioralNUnit
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
	}
}
