using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BehavioralNUnit.Specs
{
    class CollectionAssertionTests
    {
        public class ExtensionMethodTests
        {
            [Test]
            public void it_uses_regular_assertion_class_when_object_is_not_IEnumerable()
            {
                var actual = 5.Should();
                Assert.That(actual, Is.InstanceOf<ShouldBeAssertion<int>>());
            }

            [Test]
            public void it_uses_collection_assertion_class_when_object_is_IEnumerable()
            {
                var actual = new int[]{}.Should();
                Assert.That(actual, Is.InstanceOf<CollectionAssertion<int[]>>());
            }
        }

        public class EqualsMethodTests
        {
            [Test]
            public void it_asserts_equivalence()
            {
                var assertion = new CollectionAssertion<int[]>(new[] { 42 });
                (assertion == new[] { 42 }).Evaluate();
            }

            [Test]
            public void it_fails_on_non_equivalence()
            {
                var assertion = new CollectionAssertion<int[]>(new[] { 42 });
                var expression = assertion == new[] { 43 };
                Assert.Throws<AssertionException>(() => expression.Evaluate());
            }
        }        

        public class NotEqualsMethodTests
        {
            [Test]
            public void it_asserts_non_equivalence()
            {
                // TODO: dream up a better way to test non-equivalance. 
                // These two tests actually pass if you delete the method under test.
                var assertion = new CollectionAssertion<int[]>(new[] { 42 });
                (assertion != new[] { 43 }).Evaluate();
            }

            [Test]
            public void it_fails_on_equivalence()
            {
                var assertion = new CollectionAssertion<int[]>(new[] { 42 });
                var expression = assertion != new[] { 42 };
                Assert.Throws<AssertionException>(() => expression.Evaluate());
            }
        }
    }
}
