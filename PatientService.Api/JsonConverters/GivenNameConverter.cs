using PatientService.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PatientService.Api.JsonConverters
{
	public class GivenNameConverter : JsonConverter<GivenName>
	{
		public override GivenName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var value = reader.GetString();
			return new GivenName(value);
		}

		public override void Write(Utf8JsonWriter writer, GivenName value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.Value);
		}
	}
}
