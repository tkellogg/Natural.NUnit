using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BehavioralNUnit.Specs
{
	[TestFixture]
	class when_type_is_comparable
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
}
