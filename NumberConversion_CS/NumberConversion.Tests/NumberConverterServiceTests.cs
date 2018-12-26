using System;
using Xunit;

namespace NumberConversion.Tests
{
    public class NumberConverterServiceTests {

        #region Convert tests
        [Theory]
        [InlineData("Fk", 24, 6, "1432")]                                   // integer number
        [InlineData("2032.22144444444", 5, 13, "177,65A93421BA9BA3C7")]     // fractional number with '.'
        [InlineData("2X,8RDP0RPA25Xfh4L7", 34, 10, "101,259")]              // fractional number with ','
        [InlineData("42,42", 10, 10, "42,42")]                              // decimal to decimal
        public void Convert_ConvertDifferentNumbersFromAnyNumberSystemToAny_Should_ConvertCorrectly(string number, int currentSystem, int neededSystem, string expected) {
            /*Act*/
            string actual = NumberConverterService.Convert(number, currentSystem, neededSystem);

            /*Assert*/
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5, 10)]    // far from the boundary
        [InlineData(1, 10)]     // near the boundary
        [InlineData(37, 10)]    // near the boundary
        [InlineData(42, 10)]    // far from the boundary
        [InlineData(10, -5)]    // far from the boundary
        [InlineData(10, 1)]     // near the boundary
        [InlineData(10, 37)]    // near the boundary
        [InlineData(10, 42)]    // far from the boundary
        public void Convert_TryToConvertDataWithInvalidNumberSystem_Should_ThrowIndexOutOfRangeException(int currentSystem, int neededSystem) {
            /*Assert*/
            Assert.Throws<IndexOutOfRangeException>(() => NumberConverterService.Convert(string.Empty, currentSystem, neededSystem));
        }

        [Theory]
        [InlineData("%%%", 10, 10)]     // invalid symbols
        [InlineData("56*1", 10, 10)]    // invalid symbols
        [InlineData("1.1,1", 10, 10)]   // invalid symbols
        [InlineData("1,1.1", 10, 10)]   // invalid symbols
        [InlineData("1129A", 10, 10)]   // number system is lower than used char from alphabet
        [InlineData("1011,5", 2, 10)]   // number system is lower than used char from alphabet
        [InlineData("656.z2", 26, 10)]  // number system is lower than used char from alphabet
        public void Convert_TryToConvertInvalidNumber_Should_ThrowArgumentException(string number, int currentSystem, int neededSystem) {
            /*Assert*/
            Assert.Throws<ArgumentException>(() => NumberConverterService.Convert(number, currentSystem, neededSystem));
        }
        #endregion
    }
}
