using PatientService.Application.Models;
using PatientService.Application.Specifications.ComrarableSpecifications;
using PatientService.Application.Specifications.Core;
using System.Net.Http.Headers;

namespace PatientService.Application.UseCases.GetPatients.PatientFilters.DateSpecifications
{
	public static class DateSpecificationFactory
	{
		public static ISpecification<T> Create<T>(string type, T value) where T : IComparable<T>
		{
			return type switch
			{
				"eq" => new EqualSpecification<T>(value),
				"le" => new LessThanSpecification<T>(value),
				"ge" => new GreaterThanSpecification<T>(value),
				_ => throw new NotImplementedException(),
			};
		}
	}
}
