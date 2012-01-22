using System;
using NUnit.Framework;

namespace Natural.NUnit.Framework
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
			return self.EqualsOperator(other);
		}

		protected virtual ConjunctionAssertion EqualsOperator(T other)
		{
			AddAssertion(() => Assert.AreEqual(Reference, other));
			return new ConjunctionAssertion(this);
		}

		public static ConjunctionAssertion operator !=(ShouldBeAssertion<T> self, T other)
		{
			if (self == null) throw new InvalidOperationException("Assertion wrapper was null");
			return self.NotEqualsOperator(other);
		}

		protected virtual ConjunctionAssertion NotEqualsOperator(T other)
		{
			AddAssertion(() => Assert.AreNotEqual(Reference, other));
			return new ConjunctionAssertion(this);
		}

		public ConjunctionAssertion NotBe()
		{
			AddAssertion(() => Assert.Null(Reference));
			return new ConjunctionAssertion(this);
		}

		public ConjunctionAssertion BeNull
		{
			get
			{
				AddAssertion(() => Assert.NotNull(Reference));
				return new ConjunctionAssertion(this);
			}
		}

		#region Overrides from object
		public override bool Equals(object obj)
		{
			if (obj is T)
				return EqualsOperator((T)obj);
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		#endregion
	}
}
