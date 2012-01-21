using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;

namespace BehavioralNUnit
{
    public class CollectionAssertion<T> : ShouldBeAssertion<T>
    {
        public CollectionAssertion(T self)
            :base(self)
        {
        }

        protected override ConjunctionAssertion EqualsOperator(T expected)
        {
            if (!(expected is IEnumerable))
                throw new InvalidOperationException("Expected IEnumerable but got a " + typeof(T).Name);

            var expectedEnumerable = (IEnumerable)expected;
            var actualEnumerable = (IEnumerable)this.Reference;
            AddAssertion(() => Assert.That(actualEnumerable, Is.EquivalentTo(expectedEnumerable)));
            return new ConjunctionAssertion(this);
        }
    }
}
