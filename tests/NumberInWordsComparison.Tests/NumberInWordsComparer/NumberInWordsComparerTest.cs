using FluentAssertions;
using NUnit.Framework;

namespace NumberInWordsComparison.Tests.NumberInWordsComparer
{
	[TestFixture]
    public class NumberInWordsComparerTest
    {
        private IDigitsProvider digitsProvider = null!;
        private INumberInWordsComparer numberInWordsComparer = null!;
        private BigNumberInWordsGenerator bigNumberInWordsGenerator = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            digitsProvider = new DigitsProvider();
            numberInWordsComparer = new NumberInWordsComparison.NumberInWordsComparer(digitsProvider);
            bigNumberInWordsGenerator = new BigNumberInWordsGenerator(digitsProvider);
        }
        
        [TestCaseSource(typeof(NumberInWordsComparerTestCases), nameof(NumberInWordsComparerTestCases.TestCases))]
        public void Compare(string first, string second, int expected)
        {
            var actual = numberInWordsComparer.Compare(first, second);
            
            actual.Should().Be(expected);
        }

        [Timeout(1000)]
        [TestCaseSource(typeof(NumberInWordsComparerTestCases), nameof(NumberInWordsComparerTestCases.BigNumberTestCases))]
        public void Compare_BigNumbers(int lastDigit1, int lastDigit2, int expected)
        {
            var bigNumberInWords = bigNumberInWordsGenerator.Generate(digitProvider: x => (x + 1) % 10);
            var first = bigNumberInWords + digitsProvider.GetDigit(lastDigit1);
            var second = bigNumberInWords + digitsProvider.GetDigit(lastDigit2);
            
            var actual = numberInWordsComparer.Compare(first, second);
            
            actual.Should().Be(expected);
        }

        [Timeout(1000)]
        [TestCaseSource(typeof(NumberInWordsComparerTestCases), nameof(NumberInWordsComparerTestCases.BigNumberTestCases))]
        public void Compare_BorderlineBigNumbers(int firstLastDigit1, int secondLastDigit, int expected)
        {
            var bigNumberInWords = bigNumberInWordsGenerator.Generate(digitProvider: _ => 9);
            var first = bigNumberInWords + digitsProvider.GetDigit(firstLastDigit1);
            var second = bigNumberInWords + digitsProvider.GetDigit(secondLastDigit);
            
            var actual = numberInWordsComparer.Compare(first, second);
            
            actual.Should().Be(expected);
        }

        [Timeout(1000)]
        [Test]
        public void Compare_BigNumberWithZeros()
        {
            var bigNumberInWords = bigNumberInWordsGenerator.Generate(digitProvider: _ => 0);
            var first = digitsProvider.GetDigit(3) + bigNumberInWords;
            var second = digitsProvider.GetDigit(5);
            
            var actual = numberInWordsComparer.Compare(first, second);

            const int expected = 1;
            actual.Should().Be(expected);
        }
    }

}