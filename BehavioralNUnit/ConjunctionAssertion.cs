namespace BehavioralNUnit
{
	public class ConjunctionAssertion : BaseSpecification
	{
		public ConjunctionAssertion(BaseSpecification assertion)
		{
			Specifications.Add(assertion);
		}

		public static bool operator &(ConjunctionAssertion self, ConjunctionAssertion other)
		{
			return true;
		}
	}
}
