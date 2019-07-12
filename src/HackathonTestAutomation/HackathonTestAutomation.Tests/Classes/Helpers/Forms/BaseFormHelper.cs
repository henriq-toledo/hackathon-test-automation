using OpenQA.Selenium;

namespace HackathonTestAutomation.Tests.Classes.Helpers.Forms
{
    internal abstract class BaseFormHelper
    {
        protected IWebDriver webDriver;

        public BaseFormHelper()
        {
            this.webDriver = WebDriverHelper.Current;
        }
    }
}
