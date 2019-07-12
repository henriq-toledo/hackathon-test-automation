using HackathonTestAutomation.TestRunner.Forms;
using System;
using System.Windows.Forms;

namespace HackathonTestAutomation.TestRunner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestRunnerForm());
        }
    }
}
