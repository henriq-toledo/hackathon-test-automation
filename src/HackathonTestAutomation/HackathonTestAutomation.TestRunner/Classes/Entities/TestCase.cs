﻿using System;
using System.ComponentModel;
using System.Drawing;

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
        public string ExecutionId { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

        [Browsable(false)]
        public string TestClass { get; set; }

        [Browsable(false)]
        public string TestMethod { get; set; }

        [Browsable(false)]
        public string ResultFile { get; internal set; }

        [Browsable(false)]
        public string AssemblyPath { get; set; }

        public TestCase()
        {
            Status = string.Empty;
        }

        internal void InitFromTestRestult(TestResult testResult)
        {
            // TODO Name = testResult.Name;
            ExecutionId = testResult.ExecutionId;
            Duration = testResult.Duration;
            Status = testResult.Status;
            ErrorMessage = testResult.ErrorMessage;
            StackTrace = testResult.StackTrace;
        }

        internal Color StatusColor
        {
            get
            {
                Color color;

                switch (this.Status)
                {
                    case "Passed":
                        color = Color.LightGreen;
                        break;

                    case "Failed":
                        color = Color.Red;
                        break;
                    case "":
                        color = Color.White;
                        break;
                    default:
                        color = Color.Yellow;
                        break;

                }

                return color;
            }
        }
    }
}
