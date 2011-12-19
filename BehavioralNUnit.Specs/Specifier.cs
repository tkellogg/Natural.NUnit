using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehavioralNUnit.Specs
{
	public class Specifier
	{
		public BaseSpecification this[string spec]
		{
			set { value.Evaluate(); }
		}
	}
}
