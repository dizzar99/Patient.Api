using PatientService.Application.Filters;
using PatientService.Application.Filters.Abstractions;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.GetPatients.PatientFilters.DateSpecifications
{
	public class DateWithTimeFilter : IFilterHandler<Patient, PatientFilterContext>
	{
		public void ApplyFilters(FilterBuilder<Patient> builder, PatientFilterContext filterContext)
		{
			var datePropertyBuilder = builder.FilterBy(x => x.BirthDate);
			var dateFiltersWithTime = filterContext.DateFilters.Where(filter => filter.IncludeTime);

			foreach (var dateFilter in dateFiltersWithTime)
			{
				var spec = DateSpecificationFactory.Create(dateFilter.Operator, dateFilter.Value);
				datePropertyBuilder.WithSpec(spec);
			}
		}
	}
}
