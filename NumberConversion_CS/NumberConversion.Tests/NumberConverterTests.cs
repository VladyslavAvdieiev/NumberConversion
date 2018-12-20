using System;
using Xunit;

namespace NumberConversion.Tests
{
    public class NumberConverterTests {

        [Theory]
        [InlineData("3A", 33, "109")]
        [InlineData("AD", 17, "183")]
        [InlineData("423", 8, "275")]
        public void ConvertIntegerPartToDecimal_ConvertIntegerNumberFromRandomNumberSystemToDecimal_Should_ConvertCorrectly(string number, int system, string expected) {
            /*Arrange*/
            string actual;

            /*Act*/
            actual = NumberConverter.ConvertIntegerPartToDecimal(number, system);

            /*Assert*/
            Assert.Equal(expected, actual);
        }
    }
}
