using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Natural.NUnit.Specs
{
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

		/// <summary>
		/// This is a prerequisite for good range comparison support
		/// </summary>
		public class BackwardsComparisonBehavior
		{
			[Test]
			public void LessThan_works_as_expected()
			{
				(1 < 3.ShouldBe()).Evaluate();
				Assert.Throws<AssertionException>((5 < 3.ShouldBe()).Evaluate);
			}

			[Test]
			public void GreaterThan_works_as_expected()
			{
				(5 > 3.ShouldBe()).Evaluate();
				Assert.Throws<AssertionException>((1 > 3.ShouldBe()).Evaluate);
			}

			[Test]
			public void LessThanOrEqual_works_as_expected()
			{
				(3 <= 3.ShouldBe()).Evaluate();
				(1 <= 3.ShouldBe()).Evaluate();
				Assert.Throws<AssertionException>((5 <= 3.ShouldBe()).Evaluate);
			}

			[Test]
			public void GreaterThanOrEqual_works_as_expected()
			{
				(3 >= 3.ShouldBe()).Evaluate();
				(5 >= 3.ShouldBe()).Evaluate();
				Assert.Throws<AssertionException>((1 >= 3.ShouldBe()).Evaluate);
			}
		}

		public class RangeComparisonBehavior
		{
			[Test]
			public void It_can_assert_itself_within_a_range()
			{
				(1 < 3.ShouldBe() < 5).Evaluate();
			}

			[Test]
			public void It_can_fail_an_assertion_on_the_2nd_operator()
			{
				Assert.Throws<AssertionException>((1 < 3.ShouldBe() < 1).Evaluate);
			}

			[Test]
			public void It_can_pass_a_range_comparison_when_the_first_element_is_the_ShouldBe()
			{
				//(1.ShouldBe() < 3 < 5).Evaluate();
			}
		}
	}
}
