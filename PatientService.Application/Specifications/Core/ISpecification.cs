using System.Linq.Expressions;

namespace PatientService.Application.Specifications.Core
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Predicate { get; }
	}
}
