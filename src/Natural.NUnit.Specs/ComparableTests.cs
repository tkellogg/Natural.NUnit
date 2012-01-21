﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Natural.NUnit.Specs
{
	[TestFixture]
	class ComparableTests
	{
		public class DefaultComparisonBehavior
		{
			[Test]
			public void it_compares_less_than_correctly()
			{
				(4.ShouldBe() < 5).Evaluate();
			}

			[Test]
			public void it_compares_less_than_or_equal_correctly()
			{
				(5.ShouldBe() <= 5).Evaluate();
			}

			[Test]
			public void it_compares_greater_than_correctly()
			{
				(6.ShouldBe() > 5).Evaluate();
			}

			[Test]
			public void it_compares_greater_than_or_equal_correctly()
			{
				(5.ShouldBe() >= 5).Evaluate();
			}

			[Test]
			public void it_fails_if_not_less_than()
			{
				var assertion = 5.ShouldBe() < 4;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}

			[Test]
			public void it_fails_if_not_less_than_or_equal()
			{
				var assertion = 5.ShouldBe() < 4;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}

			[Test]
			public void it_fails_if_not_greater_than()
			{
				var assertion = 6.ShouldBe() < 5;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}

			[Test]
			public void it_fails_if_not_greater_than_or_equal()
			{
				var assertion = 6.ShouldBe() < 5;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}
		}

		public class RangeComparisonBehavior
		{
			[Test]
			public void It_can_assert_itself_within_a_range()
			{
				(1 < 3.ShouldBe() < 5).Evaluate();
			}
		}
	}
}
