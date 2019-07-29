using HackathonTestAutomation.Common.Classes.Attributes;
using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.TestRunner.Classes.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HackathonTestAutomation.TestRunner.Classes
{
    /// <summary>
    /// The <c>TestDiscoverer</c> class contains the infrastructure to discover the test method from an assembly
    /// </summary>
    internal class TestDiscoverer
    {
        /// <summary>
        /// Gets the test method from an assembly
        /// </summary>
        /// <param name="source">The full path from the dll</param>
        /// <returns>The test methods found</returns>
        internal List<TestCase> GetTests()
        {
            var assemblyLocation = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var projectDirectory = assemblyLocation.Directory.Parent.Parent.Parent;
            var assemblyPath = projectDirectory.FullName + @"\HackathonTestAutomation.Tests\bin\Debug\HackathonTestAutomation.Tests.dll";

            var targetAssembly = Assembly.LoadFile(assemblyPath);

            var testCases = new List<TestCase>();

            var types = targetAssembly.GetTypes();

            foreach (var classType in types)
            {
                var customAttributes = classType.CustomAttributes;

                foreach (var customAttribute in customAttributes)
                {
                    if (customAttribute.AttributeType == typeof(TestClassAttribute))
                    {
                        var methods = new List<MethodInfo>();

                        var reflectedMethods = classType.GetMethods().Where(a => a.GetCustomAttribute(typeof(TestMethodAttribute)) != null);

                        methods.AddRange(reflectedMethods);

                        foreach (var method in methods)
                        {
                            var defectAttribute = (DefectAttribute)method.GetCustomAttribute(typeof(DefectAttribute));
                            var testCase = new TestCase()
                            {
                                TestClass = classType.FullName,
                                TestMethod = method.Name,
                                Description = defectAttribute.Description,
                                Priority = defectAttribute.Priority.GetDescription(),
                                Severity = defectAttribute.Severity.GetDescription(),
                                AssemblyPath = assemblyPath
                            };

                            testCases.Add(testCase);
                        }
                    }
                }
            }

            return testCases;
        }
    }
}
