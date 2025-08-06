using PatientService.Application.Specifications.Core;
using System.Linq.Expressions;

namespace PatientService.Application.Specifications.ComparableSpecifications
{
	public class LessThanSpecification<T> : ISpecification<T> where T : IComparable<T>
	{
		private readonly T _value;

		public LessThanSpecification(T value)
		{
			_value = value;
		}

		public Expression<Func<T, bool>> Predicate => x => x.CompareTo(_value) < 0;
	}
}
