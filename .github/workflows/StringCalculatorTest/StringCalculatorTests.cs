using System;
using Xunit;
using StringCalculator;
namespace StringCalculatorTest
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = Calculator.SumString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("0", 0)]
        [InlineData("2", 2)]
        public void SingleNumberReturnTheValue(string input, int expectedResult)
        {
            int result = Calculator.SumString(input);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData("29,11", 40)]
        [InlineData("0,10", 10)]
        [InlineData("1,5", 6)]
        public void TwoNumbersCommaDelimeteredReturnTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
        [Theory]
        [InlineData("29\n11", 40)]
        [InlineData("0\n10", 10)]
        [InlineData("1\n5", 6)]
        public void TwoNumbersNewLineDelimeteredReturnTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }


        [Theory]
        [InlineData("29\n11,22", 62)]
        [InlineData("0,10,20", 30)]
        [InlineData("1,5\n10", 16)]
        public void ThreeNumbersDelimeteredEitherWayReturTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("-7,12")]
        [InlineData("12\n-7")]
        public void NegativeNumberThrwoExepction(string s)
        {
            Assert.Throws<ArgumentException>(() => Calculator.SumString(s));
        }

        [Theory]
        [InlineData("5\n1000", 5)]
        [InlineData("10,12\n1222",22)]
        [InlineData("12\n55,12345", 67)]
        public void NumberGreaterThan1000ShouldBeIgnoe(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//$\n5$5", 10)]
        [InlineData("//$\n1$1,2", 4)]
        [InlineData("//[\n12\n12[12", 36)]
        public void IfTheFirstLineStartswithDoubleslashWecadDefineAddictionalDelimeter1CharacterOnly(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//[$:]12,8$:10", 30)]
        [InlineData("//[$:!]\n1$1,2", 4)]
        [InlineData("//[===]\n12===12[12", 36)]
        public void AdditionalDelimeterCanHaveMultipleCharacters(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
    }
}
