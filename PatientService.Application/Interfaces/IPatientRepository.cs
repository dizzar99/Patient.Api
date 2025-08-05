using PatientService.Application.Specifications.Core;
using PatientService.Domain.Entities;

namespace PatientService.Application.Interfaces
{
	public interface IPatientRepository
	{
		Task<Patient> GetById(Guid id);
		Task<IEnumerable<Patient>> GetAll(ISpecification<Patient> specification);
		Task Add(Patient patient);
		Task Update(Patient patient);
		Task<bool> Delete(Guid id);
	}
}
