namespace PatientService.Application.Filters.Abstractions
{
	public interface IFilterHandler<TSource, TFilterContext>
	{
		void ApplyFilters(FilterBuilder<TSource> builder, TFilterContext filterContext);
	}
}
