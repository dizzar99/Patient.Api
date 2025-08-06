using Microsoft.Extensions.Options;
using PatientService.Generator.Models;
using System.Net.Http.Json;

namespace PatientService.Generator.Services
{
	internal class PatientServiceClient : IPatientServiceClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _url;

		public PatientServiceClient(HttpClient httpClient, IOptions<Settings> settings)
		{
			_httpClient = httpClient;
			_url = settings.Value.BaseUrl;
		}

		public async Task<bool> CreatePatient(Patient patient)
		{
			var response = await _httpClient.PostAsJsonAsync($"{_url}/patient", patient);
			return response.IsSuccessStatusCode;
		}
	}
}
