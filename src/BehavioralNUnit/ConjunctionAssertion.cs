using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;
namespace BehavioralNUnit
{
	public class ConjunctionAssertion : BaseSpecification
	{
		private readonly List<CombineType> combineTypes = new List<CombineType>();

		public enum CombineType
		{
			And, Or
		}

		public ConjunctionAssertion(BaseSpecification assertion)
		{
			AddSpec(assertion);
		}

		public static ConjunctionAssertion operator &(ConjunctionAssertion self, ConjunctionAssertion other)
		{
			var assertion = new ConjunctionAssertion(self);
			assertion.AddSpec(other, CombineType.And);
			return assertion;
		}

		private void AddSpec(ConjunctionAssertion other, CombineType and)
		{
			AddSpec(other);
			combineTypes.Add(and);
		}

		protected internal override IEnumerable<Exception> GetErrors()
		{
			if (!combineTypes.Any())
				return base.GetErrors();
			var specs = Specifications.ToList();
			var ret = specs.First().GetErrors();
			for (var i = 1; i < specs.Count; i++)
			{
				ret = combineTypes[i - 1] == CombineType.Or ? Or(ret, specs[i].GetErrors()) 
					: And(ret, specs[i].GetErrors());
			}
			return ret;
		}

		private static IEnumerable<Exception> And(IEnumerable<Exception> a, IEnumerable<Exception> b)
		{
			return a.Union(b);
		}

		private static IEnumerable<Exception> Or(IEnumerable<Exception> a, IEnumerable<Exception> b)
		{
			if (!a.Any())
				return a;
			return !b.Any() ? b : a.Union(b);
		}

		public static ConjunctionAssertion operator |(ConjunctionAssertion self, ConjunctionAssertion other)
		{
			var assertion = new ConjunctionAssertion(self);
			assertion.AddSpec(other, CombineType.Or);
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
