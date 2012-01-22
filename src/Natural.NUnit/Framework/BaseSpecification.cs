using System.Collections.Generic;
using System;
using System.Linq;

namespace Natural.NUnit.Framework
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
			if (spec == null)
				throw new ArgumentException("Specification cannot be null. It's required for making assertions later on");
			specifications.Add(spec);
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

		public static implicit operator bool(BaseSpecification self)
		{
			self.Evaluate();
			return true;
		}

	}
}
