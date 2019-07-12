using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HackathonTestAutomation.Common.Classes.Helpers
{ 
    /// <summary>
    /// The <c>EnumHelper</c> class is the helper form the <c>Enum</c>
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the description from the description attribute
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <param name="value">The enum value</param>
        /// <returns>The description from the description attribute</returns>
        public static string GetDescriptionAttributeValue<TEnum>(TEnum value) where TEnum : struct
        {
            var member = typeof(TEnum).GetMember($"{value}");
            var attributes = member.FirstOrDefault().GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;

            return description;
        }

        /// <summary>
        /// Gets the enum values
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <returns>The enum values</returns>
        public static Dictionary<TEnum, string> GetValues<TEnum>() where TEnum : struct
        {
            var dictionary = new Dictionary<TEnum, string>();

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                var description = EnumHelper.GetDescriptionAttributeValue<TEnum>(value);

                dictionary.Add(value, description);
            }

            return dictionary;
        }
    }
}
