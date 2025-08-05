using MediatR;
using PatientService.Application.Interfaces;

namespace PatientService.Application.UseCases.UpdatePatient
{
	internal class UpdatePatientCommandHandler(IPatientRepository _patientRepository) : IRequestHandler<UpdatePatientCommand, bool>
	{
		public async Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
		{
			var patient = await _patientRepository.GetById(request.Id);

			if (patient is null)
			{
				return false;
			}

			patient.Update(request.UpdateDto.Name, request.UpdateDto.IsActive, request.UpdateDto.Gender, request.UpdateDto.BirthDate);

			await _patientRepository.Update(patient);
			return true;
		}
	}
}
