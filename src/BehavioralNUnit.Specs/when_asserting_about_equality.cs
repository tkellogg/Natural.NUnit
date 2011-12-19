using NUnit.Framework;

namespace BehavioralNUnit.Specs
{
	[TestFixture]
	public class when_asserting_about_equality
	{
		[Test]
		public void it_can_fail_an_assertion_about_equality()
		{
			Assert.Throws<AssertionException>(() => (2.Should() == 3).Evaluate());
		}

		[Test]
		public void it_can_fail_an_assertion_about_inequality()
		{
			Assert.Throws<AssertionException>(() => (2.Should() != 2).Evaluate());
		}

		[Test]
		public void it_can_assert_inequality_through_an_extension_method()
		{
			(2.Should() != 3).Evaluate();
		}

		[Test]
		public void it_can_assert_equality_through_an_extension_method()
		{
			(2.Should() == 2).Evaluate();
		}

		[Test]
		public void no_exceptions_are_thrown_until_Evaluate_is_invoked()
		{
			var conjunctionAssertion = (2.Should() != 2);
			Assert.Throws<AssertionException>(conjunctionAssertion.Evaluate);
		}
	}
}
