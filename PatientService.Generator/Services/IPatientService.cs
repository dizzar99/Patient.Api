namespace PatientService.Generator.Services
{
	internal interface IPatientService
	{
		Task<bool> Generate(int count);
	}
}
