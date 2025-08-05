using PatientService.Application.Filters.Abstractions;
using PatientService.Application.Models;
using PatientService.Domain.ValueObjects;

namespace PatientService.Application.UseCases.GetPatients.PatientFilters
{
	public struct PatientFilterContext : IFilterContext
	{
		public IEnumerable<DateFilter> DateFilters { get; private set; }
		public Gender? Gender { get; set; }

		public PatientFilterContext(IEnumerable<DateFilter> filters, Gender? gender)
		{
			DateFilters = filters;
			Gender = gender;
		}
	}
}
