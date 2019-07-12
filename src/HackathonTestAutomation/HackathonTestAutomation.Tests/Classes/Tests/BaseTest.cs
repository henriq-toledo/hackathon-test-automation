using HackathonTestAutomation.Tests.Classes.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackathonTestAutomation.Tests.Classes.Tests
{
    public class BaseTest
    {
        [TestCleanup]
        public void TearDown()
        {
            WebDriverHelper.Dispose();
        }
    }
}
