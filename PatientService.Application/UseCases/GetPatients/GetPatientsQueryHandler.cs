using MediatR;
using PatientService.Application.Filters.Abstractions;
using PatientService.Application.Interfaces;
using PatientService.Application.UseCases.GetPatients.PatientFilters;
using PatientService.Domain.Entities;

namespace PatientService.Application.UseCases.GetPatients
{
	public class GetPatientsQueryHandler(
		IFilterService<Patient, PatientFilterContext> _filterService,
		IPatientRepository _patientRepository) : IRequestHandler<GetPatientsQuery, IEnumerable<Patient>>
	{
		public async Task<IEnumerable<Patient>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
		{
			var specification = _filterService.BuildSpecification(new PatientFilterContext(request.DateFilters, request.Gender));

			var patients = await _patientRepository.GetAll(specification);

			return patients;
		}
	}
}
