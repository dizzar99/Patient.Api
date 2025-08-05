using PatientService.Application.Specifications.Core;
using System.Linq.Expressions;

namespace PatientService.Application.Filters
{
	public class PropertyFilterBuilder<T, TProperty>
	{
		private readonly FilterBuilder<T> _filterBuilder;
		private readonly Expression<Func<T, TProperty>> _propertyExpression;

		public PropertyFilterBuilder(FilterBuilder<T> filterBuilder, Expression<Func<T, TProperty>> propertyExpression)
		{
			_filterBuilder = filterBuilder;
			_propertyExpression = propertyExpression;
		}

		public PropertyFilterBuilder<T, TProperty> WithSpec(ISpecification<TProperty> spec)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var propertyAccess = Expression.Invoke(_propertyExpression, parameter);

			var specExpression = spec.Predicate;

			var combinedExpression = Expression.Lambda<Func<T, bool>>(
				Expression.Invoke(specExpression, propertyAccess),
				parameter);

			_filterBuilder.AddFilter(combinedExpression);

			return this;
		}
	}
}
