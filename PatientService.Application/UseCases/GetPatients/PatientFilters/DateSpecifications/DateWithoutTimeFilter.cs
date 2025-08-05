using PatientService.Application.Filters;
using PatientService.Application.Filters.Abstractions;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.GetPatients.PatientFilters.DateSpecifications
{
	public class DateWithoutTimeFilter : IFilterHandler<Patient, PatientFilterContext>
	{
		public void ApplyFilters(FilterBuilder<Patient> builder, PatientFilterContext filterContext)
		{
			var dateTimePropertyBuilder = builder.FilterBy(x => x.BirthDate.Date);
			var dateFiltersWithoutTime = filterContext.DateFilters.Where(filter => !filter.IncludeTime);

			foreach (var dateFilter in dateFiltersWithoutTime)
			{
				var spec = DateSpecificationFactory.Create(dateFilter.Operator, dateFilter.Value.Date);
				dateTimePropertyBuilder.WithSpec(spec);
			}
		}
	}
}
