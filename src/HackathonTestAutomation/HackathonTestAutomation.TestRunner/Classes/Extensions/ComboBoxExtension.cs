using HackathonTestAutomation.Common.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HackathonTestAutomation.TestRunner.Classes.Extensions
{
    internal static class ComboBoxExtension
    {
        internal static void Initialize<TEnum>(this ComboBox control) where TEnum : struct
        {
            void AddItem(string key, TEnum? value)
            {
                control.Items.Add(new KeyValuePair<string, TEnum?>(key, value));
            }

            AddItem(string.Empty, null);

            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                var descriptionAttribute = EnumHelper.GetDescriptionAttributeValue(enumValue);

                AddItem(descriptionAttribute, enumValue);
            }

            control.DisplayMember = "Key";
            control.ValueMember = "Value";
            control.SelectedIndex = -1;
        }
    }
}
