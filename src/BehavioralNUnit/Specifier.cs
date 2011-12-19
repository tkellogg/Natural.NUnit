namespace BehavioralNUnit
{
	public class Specifier
	{
		public BaseSpecification this[string spec]
		{
			set { value.Evaluate(); }
		}
	}
}
