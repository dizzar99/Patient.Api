using MediatR;
using PatientService.Application.DTOs;

namespace PatientService.Application.UseCases.UpdatePatient
{
	public record UpdatePatientCommand(Guid Id, UpdatePatientDTO UpdateDto) : IRequest<bool>
	{
	}
}
