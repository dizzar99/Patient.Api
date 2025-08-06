using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientService.Application.DTOs;
using PatientService.Application.Models;
using PatientService.Application.UseCases.CreatePatient;
using PatientService.Application.UseCases.DeletePatient;
using PatientService.Application.UseCases.GetPatientById;
using PatientService.Application.UseCases.GetPatients;
using PatientService.Application.UseCases.UpdatePatient;
using PatientService.Domain.Entities;

namespace PatientService.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PatientController(ISender _sender) : ControllerBase
	{
		[HttpGet("{id:guid}", Name = "GetPatientById")]
		public async Task<Patient> GetById(Guid id)
		{
			var patient = await _sender.Send(new GetPatientByIdQuery(id));

			return patient;
		}

		[HttpGet(Name = "GetAllPatients")]
		public async Task<IEnumerable<Patient>> GetAll([FromQuery] string[] date)
		{
			var dateFilters = date.Select(DateFilter.Parse);

			var query = new GetPatientsQuery(dateFilters, null);
			var results = await _sender.Send(query);

			return results;
		}

		[HttpPost(Name = "CreatePatient")]
		public async Task<Patient> Create([FromBody] CreatePatientCommand command)
		{
			var createdPatient = await _sender.Send(command);
			return createdPatient;
		}

		[HttpDelete("{id:guid}", Name = "DeletePatient")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var command = new DeletePatientCommand(id);
			var isDeleted = await _sender.Send(command);

			return isDeleted ? NoContent() : NotFound();
		}

		[HttpPut("{id:guid}", Name = "UpdatePatient")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePatientDTO dto)
		{
			var updateCommand = new UpdatePatientCommand(id, dto);
			var result = await _sender.Send(updateCommand);

			return result ? NoContent() : BadRequest();
		}
	}
}
