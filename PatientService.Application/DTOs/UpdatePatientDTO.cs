using PatientService.Domain.ValueObjects;

namespace PatientService.Application.DTOs
{
	public record UpdatePatientDTO(Name Name, bool IsActive, DateTimeOffset BirthDate, Gender Gender)
	{
	}
}
