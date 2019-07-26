using System;
using System.Drawing;

namespace HackathonTestAutomation.TestRunner.Classes.Entities
{
    public abstract class BaseTest
    {
        public string Name { get; set; }
        public string ExecutionId { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

        public BaseTest()
        {
            this.Status = string.Empty;
        }

        internal bool IsStatusEmpty()
        {
            return string.IsNullOrEmpty(this.Status);
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
