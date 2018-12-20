using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConversion
{
    public static class NumberConverter {
        /// <summary>
        /// Alphabet of number systems.
        /// </summary>
        public static IList<char> Alphabet { get => _alphabet.AsReadOnly(); }
        private static List<char> _alphabet = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B',
                                                               'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                                               'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Converts integer part of number from any number system to decimal one.
        /// </summary>
        /// <param name="integerPartOfNumber">Any number in any number system.</param>
        /// <param name="system">Number system of that number.</param>
        public static string ConvertIntegerPartToDecimal(string integerPartOfNumber, int system) {
            /*Converting mechanism*/
            int dec = 0;
            int degree = integerPartOfNumber.Length;
            foreach (char digit in integerPartOfNumber)
                dec += (int)(Alphabet.IndexOf(digit) * Math.Pow(system, --degree));

            return dec.ToString();
        }

        /// <summary>
        /// Converts integer part of number from decimal number system to any one.
        /// </summary>
        /// <param name="integerPartOfNumber">Any number in decimal number system.</param>
        /// <param name="system">Number system in which number should be converted to.</param>
        public static string ConvertIntegerPartToAnySystem(string integerPartOfNumber, int system) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts fraction part of number from any number system to decimal one.
        /// </summary>
        /// <param name="fractionPartOfNumber">Any number in any number system.</param>
        /// <param name="system">Number system of that number.</param>
        public static string ConvertFractionPartToDecimal(string fractionPartOfNumber, int system) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts fraction part of number from decimal number system to any one.
        /// </summary>
        /// <param name="fractionPartOfNumber">Any number in decimal number system.</param>
        /// <param name="system">Number system in which number should be converted to.</param>
        public static string ConvertFractionPartToAnySystem(string fractionPartOfNumber, int system) {
            throw new NotImplementedException();
        }
    }
}
