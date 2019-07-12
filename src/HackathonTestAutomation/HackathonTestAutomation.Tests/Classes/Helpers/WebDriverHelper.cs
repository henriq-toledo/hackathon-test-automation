using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace HackathonTestAutomation.Tests.Classes.Helpers
{
    internal class WebDriverHelper
    {
        private static IWebDriver _instance;

        public static IWebDriver Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirefoxDriver();
                }

                return _instance;
            }
        }

        public static void Dispose()
        {
            _instance.Dispose();
            _instance = null;
        }
    }
}
