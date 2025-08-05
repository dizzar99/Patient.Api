using MediatR;
using PatientService.Application.Interfaces;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.CreatePatient
{
	internal class CreatePatientCommandHandler(IPatientRepository _patientRepository) : IRequestHandler<CreatePatientCommand, Patient>
	{
		public async Task<Patient> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
		{
			var newPatient = new Patient(request.Name, request.IsActive, request.Gender, request.BirthDate);

			await _patientRepository.Add(newPatient);

			return newPatient;
		}
	}
}
