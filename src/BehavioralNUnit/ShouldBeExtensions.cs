using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehavioralNUnit
{
	public static class ShouldBeExtensions
	{
		public static ShouldBeAssertion<T> Should<T>(this T self)
		{
			return new ShouldBeAssertion<T>(self);
		}
	}
}
