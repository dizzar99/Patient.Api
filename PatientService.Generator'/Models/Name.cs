namespace PatientService.Generator.Models
{
	internal class Name
	{
		public string Use { get; set; }
		public string FamilyName { get; set; }
		public IList<string> GivenNames { get; set; }
	}
}
