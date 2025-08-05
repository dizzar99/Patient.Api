using System.Linq.Expressions;

namespace PatientService.Application.Specifications.Core
{
	public static class SpecificationExtensions
	{
		public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right)
		{
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (right == null) throw new ArgumentNullException(nameof(right));

			var combinedExpression = left.Predicate.And(right.Predicate);
			return new ConstructedSpecification<T>(combinedExpression);
		}

		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			var parameter = Expression.Parameter(typeof(T), "x");

			var left = Expression.Invoke(first, parameter);
			var right = Expression.Invoke(second, parameter);

			var body = Expression.AndAlso(left, right);

			return Expression.Lambda<Func<T, bool>>(body, parameter);
		}
	}
}
