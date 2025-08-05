namespace PatientService.Application.Models
{
	public struct DateFilter
	{
		public string Operator { get; private set; }
		public DateTimeOffset Value { get; private set; }
		public bool IncludeTime { get; private set; }

		public DateFilter(string @operator, DateTimeOffset value, bool includeTime)
		{
			Operator = @operator;
			Value = value;
			IncludeTime = includeTime;
		}

		public static DateFilter Parse(string parameter)
		{
			if (!TrySplitOperatorAndValue(parameter, out var @operator, out var rawValue))
			{
				throw new ArgumentException($"Invalid condition format: {parameter}");
			}

			if (!DateTimeOffset.TryParse(rawValue, out var date))
			{
				throw new ArgumentException($"Invalid date format: {parameter}");
			}

			var containsTime = date.TimeOfDay != TimeSpan.Zero;

			return new DateFilter(@operator, date, containsTime);
		}

		private static bool TrySplitOperatorAndValue(string input, out string @operator, out string value)
		{
			if (input.Length < 3)
			{
				@operator = string.Empty;
				value = string.Empty;
				return false;
			}

			@operator = input.Substring(0, 2);
			value = input.Substring(2);
			return true;
		}
	}
}
