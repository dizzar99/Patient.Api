using MediatR;
using PatientService.Application.Models;
using PatientService.Domain.Entities;
using PatientService.Domain.ValueObjects;

namespace PatientService.Application.UseCases.GetPatients
{
	public record GetPatientsQuery(IEnumerable<DateFilter> DateFilters,
		Gender? Gender) : IRequest<IEnumerable<Patient>>
	{ }
}
