using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Natural.NUnit.Framework;

namespace Natural.NUnit
{
	public static class ShouldBeExtensions
	{

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
