namespace PatientService.Generator.Services
{
	internal class PatientServiceGenerator : IPatientService
	{
		private readonly IPatientServiceClient _client;
		private readonly IPatientGenerator _generator;

		public PatientServiceGenerator(IPatientServiceClient client, IPatientGenerator generator)
		{
			_client = client;
			_generator = generator;
		}

		public async Task<bool> Generate(int count)
		{
			var tasks = new List<Task<bool>>();

			for (int i = 0; i < count; i++)
			{
				tasks.Add(GeneratePatient());
			}

			var results = await Task.WhenAll(tasks);

			return results.All(result => result);
		}

		private async Task<bool> GeneratePatient()
		{
			var newPatient = _generator.Generate();
			var result = await _client.CreatePatient(newPatient);

			return result;
		}
	}
}
