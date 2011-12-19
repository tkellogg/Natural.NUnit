using System.Collections.Generic;
using NUnit.Framework;

namespace BehavioralNUnit
{
	public abstract class BaseSpecification
	{
		protected readonly List<BaseSpecification> Specifications;

		protected BaseSpecification()
		{
			Specifications = new List<BaseSpecification>();
		}

		public virtual void Evaluate()
		{
			
		}
	}
}
