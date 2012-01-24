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

		public ConjunctionAssertion NotBeNull
		{
			get
			{
				AddAssertion(() => Assert.NotNull(Reference));
				return new ConjunctionAssertion(this);
			}
		}

		public ConjunctionAssertion BeNull
		{
			get
			{
				AddAssertion(() => Assert.Null(Reference));
				return new ConjunctionAssertion(this);
			}
		}

		public ShouldBeAssertion<T> Be
		{
			get
			{
				return new ShouldBeAssertion<T>(Reference);
			}
		}

		#region Comparison operators

		private static void AddAssertion(Action<IComparable, IComparable> method, ShouldBeAssertion<T> self, T actual, T expected)
		{
			if (!(actual is IComparable)) throw new ArgumentException("Expected IComparable but got " + typeof(T).FullName);
			if (!(expected is IComparable)) throw new ArgumentException("Expected IComparable but got " + typeof(T).FullName);
			self.AddAssertion(() => method((IComparable)actual, (IComparable)expected));
		}

		public static RangeConjunctionAssertion<T> operator <(ShouldBeAssertion<T> self, T other)
		{
			AddAssertion(Assert.Less, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		public static RangeConjunctionAssertion<T> operator >(ShouldBeAssertion<T> self, T other)
		{
			AddAssertion(Assert.Greater, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		public static RangeConjunctionAssertion<T> operator <=(ShouldBeAssertion<T> self, T other)
		{
			AddAssertion(Assert.LessOrEqual, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		public static RangeConjunctionAssertion<T> operator >=(ShouldBeAssertion<T> self, T other)
		{
			AddAssertion(Assert.GreaterOrEqual, self, self.Reference, other);
			return new RangeConjunctionAssertion<T>(self, other);
		}

		#region opposite direction
		public static RangeConjunctionAssertion<T> operator <(T other, ShouldBeAssertion<T> self)
		{
			AddAssertion(Assert.Less, self, other, self.Reference);
			return new RangeConjunctionAssertion<T>(self, self.Reference);
		}

		public static RangeConjunctionAssertion<T> operator >(T other, ShouldBeAssertion<T> self)
		{
			AddAssertion(Assert.Greater, self, other, self.Reference);
			return new RangeConjunctionAssertion<T>(self, self.Reference);
		}

		public static ConjunctionAssertion operator <=(T other, ShouldBeAssertion<T> self)
		{
			AddAssertion(Assert.LessOrEqual, self, other, self.Reference);
			return new ConjunctionAssertion(self);
		}

		public static ConjunctionAssertion operator >=(T other, ShouldBeAssertion<T> self)
		{
			AddAssertion(Assert.GreaterOrEqual, self, other, self.Reference);
			return new ConjunctionAssertion(self);
		}

		#endregion

		#endregion

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
