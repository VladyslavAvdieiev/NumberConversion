using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConversion
{
    public interface IConverter {
        /// <summary>
        /// Converts integer part of number from any number system to decimal one.
        /// </summary>
        /// <param name="integerPartOfNumber">Any number in any number system.</param>
        /// <param name="system">Number system of that number.</param>
        string ConvertIntegerPartToDecimal(string integerPartOfNumber, int system);

        /// <summary>
        /// Converts integer part of number from decimal number system to any one.
        /// </summary>
        /// <param name="integerPartOfNumber">Any number in decimal number system.</param>
        /// <param name="system">Number system in which number should be be converted.</param>
        string ConvertIntegerPartToAnySystem(string integerPartOfNumber, int system);

        /// <summary>
        /// Converts fraction part of number from any number system to decimal one.
        /// </summary>
        /// <param name="fractionPartOfNumber">Any number in any number system.</param>
        /// <param name="system">Number system of that number.</param>
        string ConvertFractionPartToDecimal(string fractionPartOfNumber, int system);

        /// <summary>
        /// Converts fraction part of number from decimal number system to any one.
        /// </summary>
        /// <param name="fractionPartOfNumber">Any number in decimal number system.</param>
        /// <param name="system">Number system in which number should be converted.</param>
        string ConvertFractionPartToAnySystem(string fractionPartOfNumber, int system);
    }
}
