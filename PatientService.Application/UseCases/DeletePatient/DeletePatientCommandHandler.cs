using MediatR;
using PatientService.Application.Interfaces;

namespace PatientService.Application.UseCases.DeletePatient
{
	internal class DeletePatientCommandHandle(IPatientRepository _patientRepository) : IRequestHandler<DeletePatientCommand, bool>
	{
		public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
		{
			var isDeleted = await _patientRepository.Delete(request.Id);
			return isDeleted;
		}
	}
}
