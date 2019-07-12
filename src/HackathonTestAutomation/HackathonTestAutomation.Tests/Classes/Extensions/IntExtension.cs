﻿using System;
using System.Threading;

namespace HackathonTestAutomation.Tests.Classes.Extensions
{
    internal static class IntExtension
    {
        internal static void SleepFromSeconds(this int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
