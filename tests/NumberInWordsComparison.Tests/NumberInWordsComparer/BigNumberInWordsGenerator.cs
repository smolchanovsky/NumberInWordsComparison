using System;
using System.Linq;
using System.Text;

namespace NumberInWordsComparison.Tests.NumberInWordsComparer
{
	public class BigNumberInWordsGenerator
	{
		private readonly IDigitsProvider digitsProvider;

		public BigNumberInWordsGenerator(IDigitsProvider digitsProvider)
		{
			this.digitsProvider = digitsProvider;
		}
		
		public string Generate(Func<int, int> digitProvider)
		{
			const int numberLength = 200000;
			var maxDigitStringSize = digitsProvider.GetDigits().Select(x => x.Length).Max();
            
			var numberInWordsBuilder = new StringBuilder(maxDigitStringSize * numberLength);
			return Enumerable
				.Range(0, numberLength)
				.Select(digitProvider)
				.Aggregate(numberInWordsBuilder, (stringBuilder, x) => stringBuilder.Append(digitsProvider.GetDigit(x)))
				.ToString();
		}
	}
}