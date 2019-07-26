using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonTestAutomation.TestRunner.Classes.Extensions
{
    /// <summary>
    /// The <c>StringExtension</c> class has the extension methods of the <c>String</c> class
    /// </summary>
    internal static class StringExtension
    {
        /// <summary>
        /// Converts the string to time span
        /// </summary>
        /// <param name="value">The string value</param>
        /// <returns>The string converted to a time span</returns>
        internal static TimeSpan ToTimeSpan(this string value)
        {
            return TimeSpan.Parse(value);
        }
    }
}
