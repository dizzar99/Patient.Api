using Microsoft.EntityFrameworkCore;
using PatientService.Application.Interfaces;
using PatientService.Application.Specifications.Core;
using PatientService.Domain.Entities;

namespace PatientService.Infrastructure.Database.Repositories
{
	public class PatientRepository(AppDbContext _context) : IPatientRepository
	{
		public async Task Add(Patient patient)
		{
			_context.Patients.Add(patient);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> Delete(Guid id)
		{
			var patient = await this.GetById(id);

			if (patient is null)
			{
				return false;
			}

			_context.Patients.Remove(patient);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<IEnumerable<Patient>> GetAll(ISpecification<Patient> specification)
		{
			return await _context.Patients.Where(specification.Predicate).ToListAsync();
		}

		public async Task<Patient> GetById(Guid id)
		{
			return await _context.Patients.FindAsync(id);
		}

		public async Task Update(Patient patient)
		{
			_context.Patients.Update(patient);
			await _context.SaveChangesAsync();
		}
	}
}
