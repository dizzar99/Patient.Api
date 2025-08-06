using MediatR;
using PatientService.Application.Interfaces;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.GetPatientById
{
	internal class GetPatientByIdQueryHandler(IPatientRepository _patientRepository) : IRequestHandler<GetPatientByIdQuery, Patient>
	{
		public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
		{
			var patient = await _patientRepository.GetById(request.id);

			return patient;
		}
	}
}
