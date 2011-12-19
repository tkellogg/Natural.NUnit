using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BehavioralNUnit.Specs
{
	[TestFixture]
	class when_asserting_about_existence
	{
		[Test]
		public void null_is_definitely_null()
		{
			object nil = null;
			(nil.Should().NotBe()).Evaluate();
		}

		[Test]
		public void a_nonnull_object_is_definitely_not_null()
		{
			(5.Should().Be()).Evaluate();
		}

		[Test]
		public void Be_method_evaluates_only_when_Evaluate_is_invoked()
		{
			object nil = null;
			var eval = nil.Should().Be();
			Assert.Throws<AssertionException>(eval.Evaluate);
		}

		[Test]
		public void NotBe_method_evaluates_only_when_Evaluate_is_invoked()
		{
			var eval = 42.Should().NotBe();
			Assert.Throws<AssertionException>(eval.Evaluate);
		}
	}
}
