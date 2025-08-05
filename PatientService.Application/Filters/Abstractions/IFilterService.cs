using PatientService.Application.Specifications.Core;

namespace PatientService.Application.Filters.Abstractions
{
	public interface IFilterService<TSource, TFilterContext>
	{
		ISpecification<TSource> BuildSpecification(TFilterContext filterContext);
	}
}
