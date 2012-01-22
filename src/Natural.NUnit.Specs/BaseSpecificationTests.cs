using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using Natural.NUnit.Framework;
using System.Reflection;

namespace Natural.NUnit.Specs
{
	class BaseSpecificationTests
	{
		public class ImplicitOperatorTests
		{
			private static Mock<BaseSpecification> Given_a_mocked_BaseSpecification()
			{
				var mocked = new Mock<BaseSpecification>(MockBehavior.Strict);
				mocked.Setup(x => x.Evaluate());
				return mocked;
			}

			[Test]
			public void it_calls_Evaluate()
			{
				var mocked = Given_a_mocked_BaseSpecification();
				bool convertedValue = mocked.Object;
				mocked.VerifyAll();
			}

			[Test]
			public void it_returns_true_with_no_errors()
			{
				var mocked = Given_a_mocked_BaseSpecification();
				bool convertedValue = mocked.Object;
				Assert.That(convertedValue);
			}

			[Test]
			public void Examples()
			{
				Assert.That(42.Should() == 42);
				Assert.Throws<AssertionException>(() => Assert.That(42.Should() != 42));
			}
		}

		public class NegationUranaryOperatorTests
		{
			[Test]
			public void It_sets_the_Negated_flag()
			{
				var specification = new Mock<BaseSpecification>() { CallBase = true };
				var negatedSpec = !specification.Object;

				var negatedField = typeof(BaseSpecification).GetProperty("Negated", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(negatedSpec, null);
				Assert.That(negatedField, Is.True);
			}

			[Test]
			public void It_throws_if_there_are_no_errors()
			{
				var specification = new Mock<BaseSpecification>() { CallBase = true };
				var noErrors = new Exception[0];
				specification.Protected().Setup<IEnumerable<Exception>>("GetErrors").Returns(noErrors);
				var negatedSpec = !specification.Object;

				Assert.Throws<AssertionException>(() => { bool converted = negatedSpec; });
			}

			[Test]
			public void It_dosnt_throw_if_there_are_errors()
			{
				var specification = new Mock<BaseSpecification>() { CallBase = true };
				var errors = new []{ new Exception() };
				specification.Protected().Setup<IEnumerable<Exception>>("GetErrors").Returns(errors);
				var negatedSpec = !specification.Object;

				bool implicitlyConverted = negatedSpec;
				Assert.That(implicitlyConverted, Is.True);
			}
		}
	}
}
