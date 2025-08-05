using System.Linq.Expressions;

namespace PatientService.Application.Specifications.Core
{
	internal class ConstructedSpecification<T> : ISpecification<T>
	{
		public ConstructedSpecification(Expression<Func<T, bool>> expression)
		{
			Predicate = expression;
		}

		public Expression<Func<T, bool>> Predicate { get; }
	}

	internal class DefaultSpecification<T> : ISpecification<T>
	{
		public Expression<Func<T, bool>> Predicate => x => true;
	}
}
