using HackathonTestAutomation.Tests.Classes.Helpers.Forms;
using HackathonTestAutomation.Tests.Interfaces;
using OpenQA.Selenium;

namespace HackathonTestAutomation.Tests.Classes.Controls
{
    internal abstract class BaseInputControl<TType, TFormHelper> : BaseControl<TFormHelper>, IGetter<TType, TFormHelper>, ISetter<TType, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        protected abstract TType Value { get; set; }

        public TFormHelper GetValue(out TType value)
        {
            value = this.Value;

            return this.FormHelper;
        }

        public TFormHelper SetValue(TType value)
        {
            this.Value = value;

            return this.FormHelper;
        }

        internal BaseInputControl(By findBy, TFormHelper formHelper) : base(findBy, formHelper)
        {
        }
    }
}