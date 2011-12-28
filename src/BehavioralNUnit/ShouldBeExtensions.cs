using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehavioralNUnit
{
	public static class ShouldBeExtensions
	{

		public static ShouldBeComparableAssertion<T> ShouldBe<T>(this T self)
			where T : IComparable
		{
			return new ShouldBeComparableAssertion<T>(self);
		}

		public static ShouldBeAssertion<T> Should<T>(this T self)
		{
			return new ShouldBeAssertion<T>(self);
		}

		/// <summary>
		/// Collection Assertions
		/// </summary>
		public static CollectionAssertions<IEnumerable<T>, T> ShouldHave<T> (this IEnumerable<T> self)
		{
			return new CollectionAssertions<IEnumerable<T>, T>(self);
		}
	}
}
