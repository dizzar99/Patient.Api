using PatientService.Generator.Models;

namespace PatientService.Generator.Services
{
	internal class PatientGenerator : IPatientGenerator
	{
		private static string[] useNames = new[]
		{
			"oficial", "nonoficial"
		};

		private static string[] familyNames = new[]
		{
			"family1", "family2","family3","family4"
		};

		private static string[] givenNames = new[]
		{
			"given1", "given2", "given3","given4"
		};

		private static Random random = new Random();

		public Patient Generate()
		{
			var name = new Name
			{
				FamilyName = GetRandomString(familyNames),
				Use = GetRandomString(useNames),
				GivenNames = GetRandomStrings(givenNames)
			};

			var patient = new Patient
			{
				IsActive = random.Next(10) > 5,
				BirthDate = DateTimeOffset.UtcNow,
				Name = name,
				Gender = Enum.Parse<Gender>(GetRandomString(Enum.GetNames<Gender>()))
			};

			return patient;
		}

		private static string GetRandomString(string[]source)
		{
			var index = random.Next(source.Length);
			return source[index];
		}

		private static string[] GetRandomStrings(string[] source)
		{
			var result = new string[random.Next(3)];
			for (var i = 0; i < result.Length; i++)
			{
				result[i] = GetRandomString(source);
			}

			return result;
		}
	}
}
