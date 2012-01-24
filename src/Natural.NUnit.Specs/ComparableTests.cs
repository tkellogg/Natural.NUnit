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
				(4.Should() < 5).Evaluate();
			}

			[Test]
			public void it_compares_less_than_or_equal_correctly()
			{
				(5.Should() <= 5).Evaluate();
			}

			[Test]
			public void it_compares_greater_than_correctly()
			{
				(6.Should() > 5).Evaluate();
			}

			[Test]
			public void it_compares_greater_than_or_equal_correctly()
			{
				(5.Should() >= 5).Evaluate();
			}

			[Test]
			public void it_fails_if_not_less_than()
			{
				var assertion = 5.Should() < 4;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}

			[Test]
			public void it_fails_if_not_less_than_or_equal()
			{
				var assertion = 5.Should() < 4;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}

			[Test]
			public void it_fails_if_not_greater_than()
			{
				var assertion = 6.Should() < 5;
				Assert.Throws<AssertionException>(assertion.Evaluate);
			}

			[Test]
			public void it_fails_if_not_greater_than_or_equal()
			{
				var assertion = 6.Should() < 5;
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
				(1 < 3.Should()).Evaluate();
				Assert.Throws<AssertionException>((5 < 3.Should()).Evaluate);
			}

			[Test]
			public void GreaterThan_works_as_expected()
			{
				(5 > 3.Should()).Evaluate();
				Assert.Throws<AssertionException>((1 > 3.Should()).Evaluate);
			}

			[Test]
			public void LessThanOrEqual_works_as_expected()
			{
				(3 <= 3.Should()).Evaluate();
				(1 <= 3.Should()).Evaluate();
				Assert.Throws<AssertionException>((5 <= 3.Should()).Evaluate);
			}

			[Test]
			public void GreaterThanOrEqual_works_as_expected()
			{
				(3 >= 3.Should()).Evaluate();
				(5 >= 3.Should()).Evaluate();
				Assert.Throws<AssertionException>((1 >= 3.Should()).Evaluate);
			}
		}

		public class RangeComparisonBehavior
		{
			[Test]
			public void It_can_assert_itself_within_a_range_of_LessThan_operators()
			{
				(1 < 3.Should() < 5).Evaluate();
			}

			[Test]
			public void It_can_fail_an_assertion_on_the_2nd_LessThan_operator()
			{
				Assert.Throws<AssertionException>((1 < 3.Should() < 1).Evaluate);
			}

			[Test]
			public void It_can_assert_itself_within_a_range_of_GreaterThan_operators()
			{
				(5 > 3.Should() > 1).Evaluate();
			}

			[Test]
			public void It_can_fail_an_assertion_on_the_2nd_GreaterThan_operator()
			{
				Assert.Throws<AssertionException>((5 > 3.Should() > 5).Evaluate);
			}

			[Test]
			public void It_can_assert_itself_within_a_range_of_LessThanOrEqual_operators()
			{
				(1 < 3.Should() <= 5).Evaluate();
				(1 < 3.Should() <= 3).Evaluate();
			}

			[Test]
			public void It_can_fail_an_assertion_on_the_2nd_LessThanOrEqual_operator()
			{
				Assert.Throws<AssertionException>((1 < 3.Should() <= 1).Evaluate);
			}

			[Test]
			public void It_can_assert_itself_within_a_range_of_GreaterThanOrEqual_operators()
			{
				(5 > 3.Should() >= 1).Evaluate();
				(5 > 3.Should() >= 3).Evaluate();
			}

			[Test]
			public void It_can_fail_an_assertion_on_the_2nd_GreaterThanOrEqual_operator()
			{
				Assert.Throws<AssertionException>((5 > 3.Should() >= 5).Evaluate);
			}

			[Test]
			public void It_can_assert_a_range_and_then_conjunct_with_another_expression()
			{
				(1 < 3.Should() < 5 && 42.Should() == 42).Evaluate();
				Assert.Throws<AssertionException>((1 < 3.Should() < 5 && 42.Should() != 42).Evaluate);
				Assert.Throws<AssertionException>((1 < 3.Should() < 1 && 42.Should() == 42).Evaluate);

				(1 < 3.Should() < 5 || 42.Should() == 42).Evaluate();
				(1 < 3.Should() < 5 || 42.Should() != 42).Evaluate();
				(1 < 3.Should() < 1 || 42.Should() == 42).Evaluate();
			}

			[Test]
			public void It_can_assert_a_range_and_then_conjunct_with_another_range()
			{
				(1 < 3.Should() < 5 && 5 > 3.Should() > 1).Evaluate();
				Assert.Throws<AssertionException>((1 < 3.Should() < 5 && 5 > 3.Should() > 5).Evaluate);
				Assert.Throws<AssertionException>((1 < 3.Should() < 1 && 5 > 3.Should() > 1).Evaluate);

				(1 < 3.Should() < 5 || 5 > 3.Should() > 1).Evaluate();
				(1 < 3.Should() < 5 || 5 > 3.Should() > 5).Evaluate();
				(1 < 3.Should() < 1 || 5 > 3.Should() > 1).Evaluate();
			}

			public class WhenTheFirstElementIsThe_Should
			{
				[Test]
				public void It_can_do_a_range_comparison_using_LessThan()
				{
					(1.Should() < 3 < 5).Evaluate();
					Assert.Throws<AssertionException>((5.Should() < 3 < 5).Evaluate);
				}

				[Test]
				public void It_can_do_a_range_comparison_using_GreaterThan()
				{
					(5.Should() > 3 > 1).Evaluate();
					Assert.Throws<AssertionException>((1.Should() > 3 > 1).Evaluate);
				}

				[Test]
				public void It_can_do_a_range_comparison_using_LessThanOrEqual()
				{
					(1.Should() <= 3 < 5).Evaluate();
					(3.Should() <= 3 < 5).Evaluate();
					Assert.Throws<AssertionException>((5.Should() <= 3 < 5).Evaluate);
				}

				[Test]
				public void It_can_do_a_range_comparison_using_GreaterThanOrEqual()
				{
					(5.Should() >= 3 > 1).Evaluate();
					(3.Should() >= 3 > 1).Evaluate();
					Assert.Throws<AssertionException>((1.Should() >= 3 > 1).Evaluate);
				}
			}
		}
	}
}
