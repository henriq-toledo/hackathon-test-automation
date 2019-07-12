using System.ComponentModel;

namespace HackathonTestAutomation.Tests.Enums
{
    internal enum ExperienceLevelEnum
    {
        [Description("Experience Level")]
        None,

        [Description("Early Professional (<3 years)")]
        EarlyProfessional,

        [Description("Executive")]
        Executive,

        [Description("Intern")]
        Intern,

        [Description("Professional (>3 years)")]
        Professional
    }
}
