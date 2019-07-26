using HackathonTestAutomation.TestRunner.Classes.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HackathonTestAutomation.TestRunner.Classes.Extensions;

namespace HackathonTestAutomation.TestRunner.Classes
{
    /// <summary>
    /// The <c>TestResultRetriever</c> class contains the infrastructure to retrieve the test result from the test result file
    /// </summary>
    internal class TestResultRetriever
    {
        private XDocument _xDocument;

        /// <summary>
        /// The <c>TestResultRetriever</c> class contains the infrastructure to retrieve the test result from the test result file
        /// </summary>
        /// <param name="fileName">The test result file name</param>
        internal TestResultRetriever(string fileName)
        {
            this._xDocument = XDocument.Load(fileName);
        }

        /// <summary>
        /// Retrieves the test result from the test result file
        /// </summary>
        /// <returns></returns>
        internal List<TestResult> Retrieve()
        {
            var testDefinitions = this.TestDefinitions;

            var unitTestResults = this.UnitTestResults;

            var testResults = from testDefinition in testDefinitions
                              join unitTestResult in unitTestResults
                              on new { testDefinition.ExecutionId } equals new { unitTestResult.ExecutionId }
                              select new TestResult
                              {
                                  Name = testDefinition.Name,
                                  ExecutionId = testDefinition.ExecutionId,
                                  Duration = unitTestResult.Duration,
                                  Status = unitTestResult.Status,
                                  ErrorMessage = unitTestResult.ErrorMessage,
                                  StackTrace = unitTestResult.StackTrace
                              };

            return testResults.ToList();
        }

        private UnitTestResult[] UnitTestResults => this._xDocument
            .DescendantsByLocalName("UnitTestResult")
            .Select(n =>
            {
                return new UnitTestResult()
                {
                    ExecutionId = n.Attribute(XName.Get("executionId")).Value,
                    Duration = n.Attribute(XName.Get("duration")).Value.ToTimeSpan(),
                    Status = n.Attribute(XName.Get("outcome")).Value,
                    ErrorMessage = n.GetValue("Message", "ErrorInfo"),
                    StackTrace = n.GetValue("StackTrace", "ErrorInfo")
                };
            }).ToArray();

        private TestDefinition[] TestDefinitions => this._xDocument
            .DescendantsByLocalName("TestDefinitions")
            .SelectMany(n => n.DescendantsByLocalName("UnitTest"))
            .Select(n =>
            {
                var execution = n.DescendantsByLocalName("Execution").FirstOrDefault();
                var testMethod = n.DescendantsByLocalName("TestMethod").FirstOrDefault();

                return new TestDefinition()
                {
                    ExecutionId = execution.Attribute(XName.Get("id")).Value,
                    Name = testMethod.Attribute(XName.Get("className")).Value + "." + testMethod.Attribute(XName.Get("name")).Value
                };
            }).ToArray();
    }
}
