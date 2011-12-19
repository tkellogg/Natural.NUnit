using System;
using NUnit.Framework;

namespace BehavioralNUnit
{
	public class ShouldBeAssertion<T> : BaseSpecification
	{
		protected readonly T Reference;

		public ShouldBeAssertion(T reference)
		{
			Reference = reference;
		}

		public static ConjunctionAssertion operator ==(ShouldBeAssertion<T> self, T other)
		{
			if (self == null) throw new InvalidOperationException("Assertion wrapper was null");
			self.AddAssertion(() => Assert.AreEqual(self.Reference, other));
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator !=(ShouldBeAssertion<T> self, T other)
		{
			if (self == null) throw new InvalidOperationException("Assertion wrapper was null");
			self.AddAssertion(() => Assert.AreNotEqual(self.Reference, other));
			return new ConjunctionAssertion(self);
		}

		public ConjunctionAssertion NotBe()
		{
			Assert.Null(Reference);
			return new ConjunctionAssertion(this);
		}

		public ConjunctionAssertion Be()
		{
			Assert.NotNull(Reference);
			return new ConjunctionAssertion(this);
		}
	}
}
