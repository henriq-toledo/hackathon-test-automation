using System;
using System.Configuration;

namespace HackathonTestAutomation.Tests.Classes.Settings
{
    /// <summary>
    /// The <c>TestSettings</c> class represents the test settings in the app.config
    /// </summary>
    internal class TestSettings
    {
        private static TestSettings _instance;

        public string CareersURL { get; private set; }
        public int RetryAfterSeconds { get; private set; }
        public int RetryMaxSeconds { get; private set; }

        private TestSettings()
        {
            this.CareersURL = this.GetKeyValue<string>(nameof(CareersURL));
            this.RetryAfterSeconds = this.GetKeyValue<int>(nameof(RetryAfterSeconds));
            this.RetryMaxSeconds = this.GetKeyValue<int>(nameof(RetryMaxSeconds));
        }

        private TReturnType GetKeyValue<TReturnType>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (value == null)
            {
                throw new Exception($"The key {key} must be added in the app settings section of the App.config file.");
            }

            return (TReturnType)Convert.ChangeType(value, typeof(TReturnType));
        }

        /// <summary>
        /// The current test settings
        /// </summary>
        internal static TestSettings Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TestSettings();
                }

                return _instance;
            }
        }       
    }
}
