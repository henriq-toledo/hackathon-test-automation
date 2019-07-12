using HackathonTestAutomation.Tests.Classes.Extensions;
using HackathonTestAutomation.Tests.Classes.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HackathonTestAutomation.Tests.Classes.Helpers
{
    internal static class RetryHelper
    {
        internal static void Retry(Func<bool> function)
        {
            Exception lastException = null;

            for (int seconds = 0; ; seconds += TestSettings.Current.RetryAfterSeconds)
            {
                if (seconds >= TestSettings.Current.RetryMaxSeconds)
                {
                    if (lastException == null == false)
                    {
                        throw lastException;
                    }
                    else
                    {
                        Assert.Fail("timeout");
                    }
                }

                try
                {
                    if (function.Invoke())
                    {
                        break;
                    }

                    TestSettings.Current.RetryAfterSeconds.SleepFromSeconds();
                }
                catch (Exception ex)
                {
                    lastException = ex;

                    TestSettings.Current.RetryAfterSeconds.SleepFromSeconds();
                }
            }
        }
    }
}
