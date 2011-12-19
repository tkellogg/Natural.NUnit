namespace BehavioralNUnit
{
	public class ConjunctionAssertion : BaseSpecification
	{
		public ConjunctionAssertion(BaseSpecification assertion)
		{
			AddSpec(assertion);
		}

		public static bool operator &(ConjunctionAssertion self, ConjunctionAssertion other)
		{
			return true;
		}
	}
}
