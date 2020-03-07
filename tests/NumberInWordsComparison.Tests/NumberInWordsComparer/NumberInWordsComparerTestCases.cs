using System.Collections.Generic;
using NUnit.Framework;

namespace NumberInWordsComparison.Tests.NumberInWordsComparer
{
	public class NumberInWordsComparerTestCases
	{
		public static IEnumerable<TestCaseData> TestCases = new[] 
        {
            new TestCaseData("Zero", "Zero", 0),
            new TestCaseData("One", "Zero", 1),
            new TestCaseData("Zero", "One", -1),
            new TestCaseData("One", "Two", -1),
            new TestCaseData("One", "One", 0),
            new TestCaseData("OneTwo", "TwoOne", -1),
            new TestCaseData("OneZero", "One", 1),
            new TestCaseData("OneEight", "Nine", 1),
            new TestCaseData("OneNine", "TwoEight", -1),
            new TestCaseData("SixNine", "TwoNine", 1),
            new TestCaseData("FiveSixOne", "SixFourOne", -1),
            new TestCaseData("OneZero", "OneOne", -1),
            new TestCaseData("ThreeTwo", "Four", 1),
            new TestCaseData("OneZeroSeven", "OneZeroSix", 1),
            new TestCaseData("Eight", "Nine", -1),
            new TestCaseData("Four", "Five", -1),
            new TestCaseData("Eight", "Seven", 1),
            new TestCaseData("OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", -1),
            new TestCaseData("OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroOne", -1),
            new TestCaseData("OneThreeTwoFourNineZeroSixFiveEightNine", "OneFourThreeTwoNineZeroSixFiveEightNine", -1),
            new TestCaseData("ThreeThreeThree", "TwoTwoTwo", 1),
            new TestCaseData("OneThreeTwoFourNineZeroSixFiveEightNine", "OneThreeTwoFourNineZeroSixFiveEightNine", 0),
            new TestCaseData("NineOneThreeTwoFourNineSixFiveEight", "OneThreeTwoFourNineZeroSixFiveEightNine", -1),
            new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", -1),
            new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneTwo", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoOne", -1),
            new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", 1),
            new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoZero", 1),
            new TestCaseData("TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", "ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", 1),
            new TestCaseData("ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", -1),
        };
        
        public static IEnumerable<TestCaseData> BigNumberTestCases = new[]
        {
            new TestCaseData(0, 1, -1),
            new TestCaseData(5, 4, 1),
            new TestCaseData(7, 7, 0),
        };
	}
}