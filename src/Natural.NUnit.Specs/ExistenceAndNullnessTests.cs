using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Natural.NUnit.Specs
{
	[TestFixture]
	class ExistenceAndNullnessTests
	{
		[Test]
		public void null_is_definitely_null()
		{
			object nil = null;
			(nil.Should().NotBeNull).Evaluate();
		}

		[Test]
		public void a_nonnull_object_is_definitely_not_null()
		{
			(5.Should().BeNull).Evaluate();
		}

		[Test]
		public void Be_method_evaluates_only_when_Evaluate_is_invoked()
		{
			object nil = null;
			var eval = nil.Should().BeNull;
			Assert.Throws<AssertionException>(eval.Evaluate);
		}

		[Test]
		public void NotBe_method_evaluates_only_when_Evaluate_is_invoked()
		{
			var eval = 42.Should().NotBeNull;
			Assert.Throws<AssertionException>(eval.Evaluate);
		}
	}
}
