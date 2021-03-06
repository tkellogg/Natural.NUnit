﻿using System;
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
			object @null = null;
			(@null.Should().BeNull).Evaluate();
			Assert.Throws<AssertionException>((42.Should().BeNull).Evaluate);
		}

		[Test]
		public void a_nonnull_object_is_definitely_not_null()
		{
			object @null = null;
			(5.Should().NotBeNull).Evaluate();
			Assert.Throws<AssertionException>((@null.Should().NotBeNull).Evaluate);
		}

		/// <summary>
		/// Outside-in spec. There's other, more terse, tests that test the same thing
		/// </summary>
		[Test]
		public void When_you_want_NotNull_just_use_the_negation_uranary_operator()
		{
			object @null = null;
			Assert.That(!5.Should().BeNull);
			Assert.Throws<AssertionException>(() => Assert.That(!@null.Should().BeNull));
		}

		[Test]
		public void BeNull_property_evaluates_only_when_Evaluate_is_invoked()
		{
			var eval = 42.Should().BeNull;
			Assert.Throws<AssertionException>(eval.Evaluate);
		}

		[Test]
		public void NotBeNull_property_evaluates_only_when_Evaluate_is_invoked()
		{
			object @null = null;
			var eval = @null.Should().NotBeNull;
			Assert.Throws<AssertionException>(eval.Evaluate);
		}
	}
}
