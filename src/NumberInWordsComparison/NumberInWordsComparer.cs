using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberInWordsComparison
{
	public interface INumberInWordsComparer
	{
		int Compare(string first, string second);
	}

	public class NumberInWordsComparer : INumberInWordsComparer
	{
		private readonly IReadOnlyDictionary<string, int> digitsByName;
		private static readonly Regex wordParser = new Regex(@"([A-Z][a-z]+)", RegexOptions.Compiled);

		public NumberInWordsComparer(IDigitsProvider digitsProvider)
		{
			digitsByName = new ReadOnlyDictionary<string, int>(digitsProvider
				.GetDigits()
				.Select((x, i) => (Digit: i, DigitString: x))
				.ToDictionary(x => x.DigitString, x => x.Digit));
		}
		
		public int Compare(string first, string second)
		{
			EnsureArgumentIsValid(first, nameof(first));
			EnsureArgumentIsValid(second, nameof(second));
			
			var firstDigits = ConvertToDigits(first);
			var secondDigits = ConvertToDigits(second);
			return CompareListsOfDigits(firstDigits.ToArray(), secondDigits.ToArray());
		}

		private IEnumerable<int> ConvertToDigits(string numberInWords)
		{
			return wordParser.Matches(numberInWords)
					.Select(x => digitsByName[x.Value])
					.ToArray();
		}

		private static int CompareListsOfDigits(ICollection<int> first, ICollection<int> second)
		{
			var comparisonByCountResult = TryCompareListsOfDigitsByCount(first, second);
			if (comparisonByCountResult.HasValue)
				return comparisonByCountResult.Value;
			
			return first
				.Zip(second)
				.Select(x => x.First.CompareTo(x.Second))
				.FirstOrDefault(x => x != 0);
				
		}
		
		private static int? TryCompareListsOfDigitsByCount(IEnumerable<int> first, IEnumerable<int> second)
		{
			var comparisonResult = first.Count().CompareTo(second.Count());
			if (comparisonResult == 0)
				return null;
			return comparisonResult;
		}

		private static void EnsureArgumentIsValid(string numberInWords, string argumentName)
		{
			if (numberInWords is null)
				throw new ArgumentNullException(argumentName);
			if (String.IsNullOrEmpty(numberInWords))
				throw new ArgumentException("The argument must be a number in words.", argumentName);
		}
	}
}