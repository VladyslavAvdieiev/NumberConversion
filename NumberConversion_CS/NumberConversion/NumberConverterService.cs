using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConversion
{
    /// <summary>
    /// Represents service of converter of integer and fraction number in different number systems.
    /// </summary>
    public static class NumberConverterService {

        /// <summary>
        /// Converts number from any number system to any one.
        /// </summary>
        /// <param name="number">Represents any number in any number system.</param>
        /// <param name="currentSystem">Represents the number system in which number is.</param>
        /// <param name="neededSystem">Represents the number system in which number should be converted to.</param>
        /// <exception cref="ArgumentException">Arguments of number are not valid.</exception>
        /// <exception cref="IndexOutOfRangeException">Number system index is out of range of alphabet.</exception>
        public static string Convert(string number, int currentSystem, int neededSystem) {
            string[] partsOfNumber = number.Split('.', ',');

            if (partsOfNumber.Length == 1) {
                string decInt = NumberConverter.ConvertIntegerPartToDecimal(partsOfNumber[0], currentSystem);
                string resInt = NumberConverter.ConvertIntegerPartToAnySystem(decInt, neededSystem);

                return resInt;
            }
            else if (partsOfNumber.Length == 2) {
                string decInt = NumberConverter.ConvertIntegerPartToDecimal(partsOfNumber[0], currentSystem);
                string resInt = NumberConverter.ConvertIntegerPartToAnySystem(decInt, neededSystem);

                string decFrac = NumberConverter.ConvertFractionPartToDecimal(partsOfNumber[1], currentSystem);
                string resFrac = NumberConverter.ConvertFractionPartToAnySystem(decFrac, neededSystem);

                return $"{resInt},{resFrac}";
            }

            throw new ArgumentException("Arguments of number are not valid.");
        }
    }
}
