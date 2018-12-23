using System;
using Xunit;

namespace NumberConversion.Tests
{
    public class NumberConverterTests {

        #region ConvertIntegerPartToDecimal tests
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

        [Theory]
        [InlineData("10.20", 10)]   // invalid symbols
        [InlineData("3,145", 10)]   // invalid symbols
        [InlineData("ABC#D", 10)]   // invalid symbols
        [InlineData("1129A", 10)]   // number system is lower than used char from alphabet
        [InlineData("110210", 2)]   // number system is lower than used char from alphabet
        [InlineData("656z2", 26)]   // number system is lower than used char from alphabet
        public void ConvertIntegerPartToDecimal_TryToConvertInvalidNumber_Should_ThrowArgumentException(string number, int system) {
            /*Assert*/
            Assert.Throws<ArgumentException>(() => NumberConverter.ConvertIntegerPartToDecimal(number, system));
        }
        #endregion

        #region ConvertIntegerPartToAnySystem tests
        [Theory]
        [InlineData("230", 23, "A0")]   // random number
        [InlineData("245", 8, "365")]   // random number
        [InlineData("186", 17, "AG")]   // random number
        [InlineData("225", 10, "225")]  // decimal to decimal
        public void ConvertIntegerPartToAnySystem_ConvertIntegerNumberFromDecimalToRandomNumberSystem_Should_ConvertCorrectly(string number, int system, string expected) {
            /*Act*/
            string actual = NumberConverter.ConvertIntegerPartToAnySystem(number, system);

            /*Assert*/
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5)]    // far from the boundary
        [InlineData(1)]     // near the boundary
        [InlineData(37)]    // near the boundary
        [InlineData(42)]    // far from the boundary
        public void ConvertIntegerPartToAnySystem_TryToConvertDataToInvalidNumberSystem_Should_ThrowIndexOutOfRangeException(int system) {
            /*Assert*/
            Assert.Throws<IndexOutOfRangeException>(() => NumberConverter.ConvertIntegerPartToAnySystem(string.Empty, system));
        }

        [Theory]
        [InlineData("10.20")]   // invalid symbols
        [InlineData("3,145")]   // invalid symbols
        [InlineData("12#88")]   // invalid symbols
        [InlineData("1129A")]   // used char from alphabet is bigger than decimal number system
        [InlineData("11b22")]   // used char from alphabet is bigger than decimal number system
        [InlineData("1C113")]   // used char from alphabet is bigger than decimal number system
        public void ConvertIntegerPartToAnySystem_TryToConvertInvalidNumber_Should_ThrowArgumentException(string number) {
            /*Assert*/
            Assert.Throws<ArgumentException>(() => NumberConverter.ConvertIntegerPartToAnySystem(number, NumberConverter.Decimal));
        }
        #endregion

        #region ConvertFractionPartToDecimal tests
        [Theory]
        [InlineData("3A", 33, "10009182736455")]    // uppercase of number
        [InlineData("ad", 17, "63321799307958")]    // lowercase of number
        [InlineData("423", 8, "537109375")]         // random number
        [InlineData("25", 10, "25")]                // decimal to decimal
        public void ConvertFractionPartToDecimal_ConvertIntegerFractionFromRandomNumberSystemToDecimal_Should_ConvertCorrectly(string number, int system, string expected) {
            /*Act*/
            string actual = NumberConverter.ConvertFractionPartToDecimal(number, system);

            /*Assert*/
            Assert.Matches(expected, actual);
        }
        #endregion
    }
}
