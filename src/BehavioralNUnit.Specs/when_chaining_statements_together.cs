using System;
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

		[Test]
		public void the_assertion_is_invoked_immediately_even_if_Evaluate_is_never_invoked()
		{
			var a = new Mock<Mockable>(MockBehavior.Strict) {CallBase = false};
			a.Setup(x => x.Equals(It.IsAny<Mockable>())).Returns(true);
			var b = new Mock<Mockable>();

			var expression = a.Object.Should() == b.Object;
			a.VerifyAll();
		}
	}
}
