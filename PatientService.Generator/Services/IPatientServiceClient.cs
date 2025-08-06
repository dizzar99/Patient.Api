using PatientService.Generator.Models;

namespace PatientService.Generator.Services
{
	internal interface IPatientServiceClient
	{
		Task<bool> CreatePatient(Patient patient);
	}
}
