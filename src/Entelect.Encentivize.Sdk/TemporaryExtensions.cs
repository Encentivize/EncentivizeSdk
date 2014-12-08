using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Entelect.Encentivize.Sdk
{
    /*todo rk, remove this class after the lib is complete*/
    public static class TemporaryExtensions
    {
        /// <summary>
        /// Takes in a Pascal Case string and spaces between the words
        /// </summary>
        /// <param name="input">The string to replace</param>
        /// <returns>The replaced string</returns>
        public static string PascalToSpacedString(this string input)
        {
            const string pascalCaseSplit = @"([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))";
            return Regex.Replace(input, pascalCaseSplit, "$1 ");
        }

        /// <summary>
        /// Determines whether the provided list of strings contains the specified string using the provided StringComparison object.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="value">The value.</param>
        /// <param name="stringComparison">The string comparison object to use.</param>
        /// <returns>True if the list contains the value otherwise false</returns>
        public static bool Contains(this IEnumerable<string> input, string value, StringComparison stringComparison)
        {
            return input.Any(item => item.Equals(value, stringComparison));
        }
    }
}