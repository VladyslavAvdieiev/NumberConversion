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

        [Theory]
        [InlineData(-5)]    // far from the boundary
        [InlineData(1)]     // near the boundary
        [InlineData(37)]    // near the boundary
        [InlineData(42)]    // far from the boundary
        public void ConvertIntegerPartToDecimal_TryToConvertDataFromInvalidNumberSystem_Should_ThrowIndexOutOfRangeException(int system) {
            /*Assert*/
            Assert.Throws<IndexOutOfRangeException>(() => NumberConverter.ConvertIntegerPartToDecimal(string.Empty, system));
        }
    }
}
