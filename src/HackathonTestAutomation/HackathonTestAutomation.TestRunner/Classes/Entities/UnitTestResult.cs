using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonTestAutomation.TestRunner.Classes.Entities
{
    internal class UnitTestResult
    {
        public string ExecutionId { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
