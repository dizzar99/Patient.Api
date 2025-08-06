using MediatR;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.GetPatientById
{
	public record GetPatientByIdQuery(Guid id) : IRequest<Patient>
	{
	}
}
