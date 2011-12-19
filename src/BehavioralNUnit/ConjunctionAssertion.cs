using System.Linq;
using NUnit.Framework;
namespace BehavioralNUnit
{
	public class ConjunctionAssertion : BaseSpecification
	{
		public ConjunctionAssertion(BaseSpecification assertion)
		{
			AddSpec(assertion);
		}

		public static ConjunctionAssertion operator &(ConjunctionAssertion self, ConjunctionAssertion other)
		{
			var assertion = new ConjunctionAssertion(self);
			assertion.AddSpec(other);
			return assertion;
		}

		private bool IsTruish
		{
			get { return !GetErrors().Any(); }
		}

		public static bool operator true(ConjunctionAssertion self)
		{
			return self.IsTruish;
		}

		public static bool operator false(ConjunctionAssertion self)
		{
			return !self.IsTruish;
		}

		public override void Evaluate()
		{
			if (!IsTruish)
				Assert.Fail("one side of the && operator failed");
			base.Evaluate();
		}
	}
}
