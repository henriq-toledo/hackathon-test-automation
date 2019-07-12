using System.ComponentModel;

namespace HackathonTestAutomation.TestRunner.Classes.Entities
{
    public class TestCase
    {
        public bool Execute { get; set; }
        public bool Executed { get; set; }
        public string Name => TestClass + "." + TestMethod;
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public string TestClass { get; set; }
        public string TestMethod { get; set; }

        [Browsable(false)]
        public string AssemblyPath { get; set; }
    }
}
