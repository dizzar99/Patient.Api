using PatientService.Domain.ValueObjects;

namespace PatientService.Domain.Entities
{
	public class Patient
	{
		public Guid Id { get; private set; }
		public DateTimeOffset BirthDate { get; private set; }
		public bool IsActive { get; private set; }
		public Name Name { get; private set; }
		public Gender Gender { get; private set; }

		private Patient()
		{ }

		public Patient(Name name, bool isActive, Gender gender, DateTimeOffset birthDate)
		{
			Id = Guid.NewGuid();
			Name = name;
			IsActive = isActive;
			BirthDate = birthDate;
			Gender = gender;
		}

		public void Update(Name name, bool isActive, Gender gender, DateTimeOffset birthDate)
		{
			Gender = gender;
			Name = name;
			IsActive = isActive;
			BirthDate = birthDate;
		}
	}
}
