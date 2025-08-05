using PatientService.Application.Filters.Abstractions;
using PatientService.Application.Specifications.Core;

namespace PatientService.Application.Filters
{
	public class FilterService<TSource, TFilterContext> : IFilterService<TSource, TFilterContext>
	{
		private readonly IEnumerable<IFilterHandler<TSource, TFilterContext>> _filterHandlers;

		public FilterService(IEnumerable<IFilterHandler<TSource, TFilterContext>> filterHandlers)
		{
			_filterHandlers = filterHandlers;
		}

		public ISpecification<TSource> BuildSpecification(TFilterContext filterContext)
		{
			var filterBuilder = new FilterBuilder<TSource>();

			foreach (var filterHandler in _filterHandlers)
			{
				filterHandler.ApplyFilters(filterBuilder, filterContext);
			}

			return filterBuilder.Build();
		}
	}
}
