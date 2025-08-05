using MediatR;

namespace PatientService.Application.UseCases.DeletePatient
{
	public record DeletePatientCommand(Guid Id) : IRequest<bool>
	{
	}
}
