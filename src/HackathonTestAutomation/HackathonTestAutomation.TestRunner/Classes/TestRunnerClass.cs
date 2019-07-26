using HackathonTestAutomation.TestRunner.Classes.Entities;
using HackathonTestAutomation.TestRunner.Classes.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HackathonTestAutomation.TestRunner.Classes
{
    internal class TestRunnerClass
    {
        public void Run(TestCase[] testCases)
        {
            foreach (var testCase in testCases)
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.WorkingDirectory = Path.GetTempPath();
                    process.Start();

                    var command = "\"" + AppSettings.Current.VsTestConsole + "\" " +
                         $"\"{testCase.AssemblyPath}\" /UseVsixExtensions:true /logger:trx /Tests:{testCase.Name}";

                    process.StandardInput.WriteLine(command);
                    process.StandardInput.Flush();
                    process.StandardInput.Close();
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();

                    var resultFile = this.GetResultFileNameFromResultFile(output);

                    testCase.ResultFile = resultFile;
                }

                var testResultRetriever = new TestResultRetriever(testCase.ResultFile);
                var testResults = testResultRetriever.Retrieve();
                var testResult = testResults.FirstOrDefault(r => r.Name == testCase.Name);

                if (testResult == null == false)
                {
                    testCase.InitFromTestRestult(testResult);
                }
            }
        }

        private string GetResultFileNameFromResultFile(string resultFileText)
        {
            var resultFile = resultFileText
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(line => line.StartsWith("Results File: "));

            resultFile = resultFile.Replace("Results File: ", string.Empty);

            return resultFile;
        }
    }
}
