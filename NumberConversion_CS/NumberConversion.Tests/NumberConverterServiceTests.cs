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
        #endregion
    }
}
