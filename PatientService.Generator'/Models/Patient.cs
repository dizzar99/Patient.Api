namespace PatientService.Generator.Models
{
	internal class Patient
	{
		public DateTimeOffset BirthDate { get; set; }
		public bool IsActive { get; set; }
		public Name Name { get; set; }
		public Gender Gender { get; set; }
	}
}
