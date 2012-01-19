using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;

namespace BehavioralNUnit.Specs
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
        }
    }
}
