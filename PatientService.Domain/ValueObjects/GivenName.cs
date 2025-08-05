namespace PatientService.Domain.ValueObjects
{
	public record GivenName
	{
		public string Value { get; set; }
		private GivenName() { }

		public GivenName(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(nameof(value));
			}

			Value = value;
		}
	}
}
