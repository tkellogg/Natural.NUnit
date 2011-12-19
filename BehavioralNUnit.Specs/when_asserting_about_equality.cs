using NUnit.Framework;

namespace BehavioralNUnit.Specs
{
	[TestFixture]
	public class when_asserting_about_equality
	{
		[Test]
		public void it_can_fail_an_assertion_about_equality()
		{
			Assert.Throws<AssertionException>(() => { var x = 2.Should() == 3; });
		}

		[Test]
		public void it_can_fail_an_assertion_about_inequality()
		{
			Assert.Throws<AssertionException>(() => { var x = 2.Should() != 2; });
		}

		[Test]
		public void it_can_assert_inequality_through_an_extension_method()
		{
			var conjunctionAssertion = 2.Should() != 3;
		}

		[Test]
		public void it_can_assert_equality_through_an_extension_method()
		{
			var conjunctionAssertion = 2.Should() == 2;
		}
	}
}
