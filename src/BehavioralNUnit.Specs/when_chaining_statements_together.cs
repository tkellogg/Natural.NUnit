﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace BehavioralNUnit.Specs
{
	[TestFixture]
	public class when_chaining_statements_together
	{
		public class Mockable
		{
			public override bool Equals(object obj) { return true; }
		}

		/// <summary>
		/// This behavior is required for multiple conjunctions to work as expected, especially OR's
		/// </summary>
		[Test]
		public void the_assertion_is_invoked_immediately_even_if_Evaluate_is_never_invoked()
		{
			var a = new Mock<Mockable>(MockBehavior.Strict) {CallBase = false};
			a.Setup(x => x.Equals(It.IsAny<Mockable>())).Returns(true);
			var b = new Mock<Mockable>();

			var expression = a.Object.Should() == b.Object;
			a.VerifyAll();
		}

		[Test]
		public void it_passes_when_given_true_AND_true()
		{
			var expression = 5.ShouldBe() > 4 && 4.ShouldBe() < 5;
			expression.Evaluate();
		}

		[Test]
		public void it_fails_when_given_false_AND_true()
		{
			var expression = 3.ShouldBe() > 4 && 4.ShouldBe() < 5;
			Assert.Throws<AssertionException>(expression.Evaluate);
		}

		[Test]
		public void it_fails_when_given_true_AND_false()
		{
			var expression = 5.ShouldBe() > 4 && 6.ShouldBe() < 5;
			Assert.Throws<AssertionException>(expression.Evaluate);
		}

		[Test]
		public void it_fails_when_given_false_AND_false()
		{
			var expression = 3.ShouldBe() > 4 && 6.ShouldBe() < 5;
			Assert.Throws<AssertionException>(expression.Evaluate);
		}

		[Test]
		public void it_always_executes_second_statment_if_first_passes()
		{
			var a = new Mock<Mockable>(MockBehavior.Strict);
			a.Setup(x => x.Equals(It.IsAny<Mockable>())).Returns(true);
			var b = new Mock<Mockable>(MockBehavior.Strict);
			var c = new Mock<Mockable>(MockBehavior.Strict);
			b.Setup(x => x.Equals(c.Object));

			var expression = a.Object.Should() == b.Object && b.Object.Should() == c.Object;
			a.VerifyAll();
			b.VerifyAll();
			Assert.Throws<AssertionException>(expression.Evaluate);
		}

		[Test]
		public void it_passes_when_given_true_or_true()
		{
			var expression = 4.ShouldBe() > 3 || 5.ShouldBe() < 6;
			expression.Evaluate();
		}

		[Test]
		public void it_passes_when_given_false_or_true()
		{
			var expression = 2.ShouldBe() > 3 || 5.ShouldBe() < 6;
			expression.Evaluate();
		}

		[Test]
		public void it_passes_when_given_true_or_false()
		{
			var expression = 4.ShouldBe() > 3 || 7.ShouldBe() < 6;
			expression.Evaluate();
		}

		[Test]
		public void it_fails_when_given_false_or_false()
		{
			var expression = 2.ShouldBe() > 3 || 7.ShouldBe() < 6;
			Assert.Throws<AssertionException>(expression.Evaluate);
		}

		[Test]
		public void it_always_executes_second_statment_if_first_fails()
		{
			var a = new Mock<Mockable>(MockBehavior.Strict);
			a.Setup(x => x.Equals(It.IsAny<Mockable>())).Returns(false);
			var b = new Mock<Mockable>(MockBehavior.Strict);
			var c = new Mock<Mockable>(MockBehavior.Strict);
			b.Setup(x => x.Equals(c.Object));

			var expression = a.Object.Should() == b.Object || b.Object.Should() == c.Object;
			a.VerifyAll();
			b.VerifyAll();
			Assert.Throws<AssertionException>(expression.Evaluate);
		}
	}
}