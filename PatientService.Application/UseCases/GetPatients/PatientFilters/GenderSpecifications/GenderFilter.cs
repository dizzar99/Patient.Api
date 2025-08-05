using PatientService.Application.Filters;
using PatientService.Application.Filters.Abstractions;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.GetPatients.PatientFilters.GenderSpecifications
{
	public class GenderFilter : IFilterHandler<Patient, PatientFilterContext>
	{
		public void ApplyFilters(FilterBuilder<Patient> builder, PatientFilterContext filterContext)
		{
			if (filterContext.Gender.HasValue)
			{
				builder.FilterBy(x => x)
					.WithSpec(new GenderSpecification(filterContext.Gender.Value));
			}
		}
	}
}
