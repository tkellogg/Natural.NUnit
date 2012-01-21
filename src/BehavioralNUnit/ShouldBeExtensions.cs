using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BehavioralNUnit
{
	public static class ShouldBeExtensions
	{

        /// <summary>
        /// Make assertions about this object using all comparable operators
        /// like ==, !=, &lt;, &lt;=, &gt;, &gt;=
        /// </summary>
        /// <typeparam name="T">any type that implements IComparable</typeparam>
		public static ShouldBeComparableAssertion<T> ShouldBe<T>(this T self)
			where T : IComparable
		{
			return new ShouldBeComparableAssertion<T>(self);
		}

        /// <summary>
        /// Make assertions about this object using the == and != operators
        /// </summary>
		public static ShouldBeAssertion<T> Should<T>(this T self)
		{
            if (self is IEnumerable)
                return new CollectionAssertion<T>(self);
			return new ShouldBeAssertion<T>(self);
		}

	}
}
