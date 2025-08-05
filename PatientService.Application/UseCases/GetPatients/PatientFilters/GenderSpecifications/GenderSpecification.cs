using PatientService.Application.Specifications.Core;
using PatientService.Domain.Entities;
using PatientService.Domain.ValueObjects;
using System.Linq.Expressions;

namespace PatientService.Application.UseCases.GetPatients.PatientFilters.GenderSpecifications
{
	public class GenderSpecification : ISpecification<Patient>
	{
		private readonly Gender _gender;
		public GenderSpecification(Gender gender)
		{
			_gender = gender;
		}

		public Expression<Func<Patient, bool>> Predicate => x => x.Gender == _gender;
	}
}
