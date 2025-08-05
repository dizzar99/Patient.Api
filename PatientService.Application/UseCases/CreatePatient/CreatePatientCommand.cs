using MediatR;
using PatientService.Domain.Entities;
using PatientService.Domain.ValueObjects;

namespace PatientService.Application.UseCases.CreatePatient
{
	public record CreatePatientCommand(
		Name Name,
		bool IsActive,
		Gender Gender,
		DateTimeOffset BirthDate) : IRequest<Patient>
	{ }
}
