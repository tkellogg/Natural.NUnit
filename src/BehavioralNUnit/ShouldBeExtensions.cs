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

	}
}
