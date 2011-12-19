using System.Collections.Generic;
using System;
using System.Linq;

namespace BehavioralNUnit
{
	public abstract class BaseSpecification
	{
		private readonly List<BaseSpecification> specifications;
		private readonly List<Exception> errors;

		protected BaseSpecification()
		{
			specifications = new List<BaseSpecification>();
			errors = new List<Exception>();
		}

		protected virtual IEnumerable<BaseSpecification> Specifications
		{
			get { return specifications; }
		}

		protected virtual IEnumerable<Exception> Errors
		{
			get { return errors; }
		}

		protected void AddSpec(BaseSpecification spec)
		{
			specifications.Add(spec);
			errors.Add(null);
		}

		protected Exception AddAssertion(Action assertion)
		{
			Exception ret = null;
			try
			{
				assertion();
			}
			catch (Exception e)
			{
				ret = e;
				errors.Add(ret);
			}
			return ret;
		}

		protected internal virtual IEnumerable<Exception> GetErrors()
		{
			var ret = new List<Exception>();
			foreach (var exception in Errors)
				if (exception != null)
					ret.Add(exception);

			foreach (var specification in Specifications)
				ret.AddRange(specification.GetErrors());

			return ret;
		}

		public virtual void Evaluate()
		{
			var first = GetErrors().FirstOrDefault();
			if (first != null)
				throw first;
		}
	}
}
