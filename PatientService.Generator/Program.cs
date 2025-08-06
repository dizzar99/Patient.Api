using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PatientService.Generator.Services;

namespace PatientService.Generator
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();

			// Configure services
			var services = new ServiceCollection();
			services
				.Configure<Settings>(configuration.GetSection("Settings"))
				.AddSingleton<IConfiguration>(configuration)
				.AddSingleton<IPatientGenerator, PatientGenerator>()
				.AddSingleton<IPatientService, PatientServiceGenerator>()
				.AddHttpClient<IPatientServiceClient, PatientServiceClient>();

			var provider = services.BuildServiceProvider();

			var patientService = provider.GetRequiredService<IPatientService>();
			var config = provider.GetRequiredService<IOptions<Settings>>().Value;

			var result = await patientService.Generate(config.PatientCount);

			Console.WriteLine(result ? "Done" : "Failed");
		}
	}
}
