using System;
using Xunit;

namespace NumberConversion.Tests
{
    public class NumberConverterTests {

        [Theory]
        [InlineData("3A", 33, "109")]   // uppercase of number
        [InlineData("ad", 17, "183")]   // lowercase of number
        [InlineData("423", 8, "275")]   // random number
        [InlineData("25", 10, "25")]    // decimal to decimal
        public void ConvertIntegerPartToDecimal_ConvertIntegerNumberFromRandomNumberSystemToDecimal_Should_ConvertCorrectly(string number, int system, string expected) {
            /*Act*/
            string actual = NumberConverter.ConvertIntegerPartToDecimal(number, system);

            /*Assert*/
            Assert.Equal(expected, actual);
        }
    }
}
