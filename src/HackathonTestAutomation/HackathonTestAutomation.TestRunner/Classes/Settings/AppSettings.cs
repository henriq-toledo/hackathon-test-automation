using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HackathonTestAutomation.TestRunner.Classes.Settings
{
    internal class AppSettings
    {
        private static AppSettings _instance;

        internal string[] TestSources { get; private set; }

        internal string VsTestConsole { get; private set; }

        private AppSettings()
        {
            this.VsTestConsole = this._VsTestConsolePath;

            this.TestSources = this._TestSourcesPath;
        }

        private string _VsTestConsolePath
        {
            get
            {
                string path;
                var keyPattern = nameof(this.VsTestConsole);

                for (int i = 1; ; i++)
                {
                    var testSourceKey = keyPattern + i.ToString();

                    if (this.ExistsKey(testSourceKey) == false)
                    {
                        throw new Exception("The vstest.console.exe path does not exist, please configure correctly and add a new VsTestConsole key in the app settings.");
                    }

                    var value = this.GetKeyValue<string>(testSourceKey);

                    if (File.Exists(value))
                    {
                        path = value;
                        break;
                    }
                }

                return path;
            }
        }

        private string[] _TestSourcesPath
        {
            get
            {
                var assemblyLocation = new FileInfo(Assembly.GetExecutingAssembly().Location);
                var projectDirectory = assemblyLocation.Directory.Parent.Parent.Parent;

                var testSources = new List<string>();
                var keyPattern = "TestSource";

                for (int i = 1; ; i++)
                {
                    var testSourceKey = keyPattern + i.ToString();

                    if (this.ExistsKey(testSourceKey) == false)
                    {
                        break;
                    }

                    var value = this.GetKeyValue<string>(testSourceKey);
                    var testSourcePath = projectDirectory.FullName + value;

                    testSources.Add(testSourcePath);
                }

                return testSources.ToArray();
            }
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
        /// Verifies if the key exists in the app settings
        /// </summary>
        /// <param name="key">The appSettings key</param>
        /// <returns>True if the key exists in the app settings; otherwise, false</returns>
        protected bool ExistsKey(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key);
        }

        internal static AppSettings Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSettings();
                }

                return _instance;
            }
        }
    }
}
