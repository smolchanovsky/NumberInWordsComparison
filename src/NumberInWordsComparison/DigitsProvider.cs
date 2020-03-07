using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NumberInWordsComparison
{
	public interface IDigitsProvider
	{
		string[] GetDigits();
		string GetDigit(int digit);
	}

	public class DigitsProvider : IDigitsProvider
	{
		private readonly IReadOnlyList<string> digits = new ReadOnlyCollection<string> (new[]
		{
			"Zero",
			"One",
			"Two",
			"Three",
			"Four",
			"Five",
			"Six",
			"Seven",
			"Eight",
			"Nine",
		});
		
		public string[] GetDigits() => digits.ToArray();

		public string GetDigit(int digit) => digits[digit];
	}
}