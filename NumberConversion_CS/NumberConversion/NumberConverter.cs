using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConversion
{
    public static class NumberConverter {
        /// <summary>
        /// Represents the value of the decimal number system.
        /// </summary>
        public const int Decimal = 10;
        /// <summary>
        /// Represents the alphabet of the number systems.
        /// </summary>
        public static IList<char> Alphabet { get => _alphabet.AsReadOnly(); }
        private static List<char> _alphabet = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B',
                                                               'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                                               'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Converts integer part of number from any number system to decimal one.
        /// </summary>
        /// <param name="integerPartOfNumber">Represents any number in any number system.</param>
        /// <param name="system">Represents the number system of that number.</param>
        public static string ConvertIntegerPartToDecimal(string integerPartOfNumber, int system) {
            /*Converting the number to one letter case*/
            integerPartOfNumber = integerPartOfNumber.ToUpper();

            /*Data verification*/
            VerifyData(integerPartOfNumber, system, system - 1);

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
        /// <param name="integerPartOfNumber">Represents any number in decimal number system.</param>
        /// <param name="system">Represents the number system in which number should be converted to.</param>
        public static string ConvertIntegerPartToAnySystem(string integerPartOfNumber, int system) {
            /*Data verification*/
            VerifyData(integerPartOfNumber, system, Decimal - 1);

            /*Converting mechanism*/
            int dec = int.Parse(integerPartOfNumber);
            string result = string.Empty;
            while (dec != 0) {
                result = Alphabet[dec % system].ToString() + result;
                dec /= system;
            }

            return result;
        }

        /// <summary>
        /// Converts fraction part of number from any number system to decimal one.
        /// </summary>
        /// <param name="fractionPartOfNumber">Represents any number in any number system.</param>
        /// <param name="system">Represents the number system of that number.</param>
        public static string ConvertFractionPartToDecimal(string fractionPartOfNumber, int system) {
            /*Converting the number to one letter case*/
            fractionPartOfNumber = fractionPartOfNumber.ToUpper();

            /*Data verification*/
            VerifyData(fractionPartOfNumber, system, system - 1);

            /*Converting mechanism*/
            double dec = 0;
            int degree = 0;
            foreach (char digit in fractionPartOfNumber)
                dec += Alphabet.IndexOf(digit) * Math.Pow(system, --degree);

            return dec.ToString().Split('.',',')[1];
        }

        /// <summary>
        /// Converts fraction part of number from decimal number system to any one.
        /// </summary>
        /// <param name="fractionPartOfNumber">Represents any number in decimal number system.</param>
        /// <param name="system">Represents the number system in which number should be converted to.</param>
        /// <param name="accuracy">Represents the accuracy of converted number.</param>
        public static string ConvertFractionPartToAnySystem(string fractionPartOfNumber, int system, int accuracy = 16) {
            /*Data verification*/
            VerifyData(fractionPartOfNumber, system, Decimal - 1);

            /*Converting mechanism*/
            decimal dec = Convert.ToDecimal($"0,{fractionPartOfNumber}");
            string result = string.Empty;
            int currentAccuracy = 0;
            while (dec != 0 && currentAccuracy < accuracy) {
                result += Alphabet[(int)(dec *= system)].ToString();
                dec -= (int)dec;
                currentAccuracy++;
            }

            return result;
        }

        private static void VerifyData(string number, int system, int boundary) {
            /*Checking the number system for belonging to boundaries*/
            if (system < 2 || system > Alphabet.Count)
                throw new IndexOutOfRangeException("Number system index is out of range.");

            /*Validation of the number*/
            foreach (char digit in number)
                if (!Alphabet.Contains(digit))
                    throw new ArgumentException("Arguments of number are not valid.");
                else if (Alphabet.IndexOf(digit) > boundary)
                    throw new ArgumentException("Arguments of number are not valid.");
        }
    }
}
