using System.Text.Json.Serialization;

namespace PatientService.Domain.ValueObjects
{
	public record Name
	{
		public string Use { get; private set; }
		public string FamilyName { get; private set; }
		public IList<GivenName> GivenNames { get; private set; }

		private Name() { }

		public Name(string use, string familyName, IList<GivenName> givenNames)
		{
			if (string.IsNullOrEmpty(familyName))
			{
				throw new ArgumentNullException(nameof(familyName));
			}

			Use = use;
			FamilyName = familyName;
			GivenNames = givenNames;
		}
	}
}
