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
			Assert.NotNull(self);
			Assert.AreEqual(self.Reference, other);
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator !=(ShouldBeAssertion<T> self, T other)
		{
			Assert.AreNotEqual(self.Reference, other);
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
