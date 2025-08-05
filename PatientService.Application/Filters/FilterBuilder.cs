using PatientService.Application.Specifications.Core;
using System.Linq.Expressions;

namespace PatientService.Application.Filters
{
	public class FilterBuilder<T>
	{
		private readonly List<ISpecification<T>> _specifications = new();

		public PropertyFilterBuilder<T, TProperty> FilterBy<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
		{
			return new PropertyFilterBuilder<T, TProperty>(this, propertyExpression);
		}

		public ISpecification<T> Build()
		{
			if (!_specifications.Any())
			{
				return new DefaultSpecification<T>();
			}

			return _specifications.Aggregate((current, next) => current.And(next));
		}

		internal void AddFilter(Expression<Func<T, bool>> filter)
		{
			_specifications.Add(new ConstructedSpecification<T>(filter));
		}
	}
}
