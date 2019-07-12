namespace HackathonTestAutomation.Common.Enums
{
    public enum SeverityEnum
    {
        /// <summary>
        /// 1 - Critical
        /// </summary>
        Critical = 1,

        /// <summary>
        /// 2 - Major
        /// </summary>
        Major = 2,

        /// <summary>
        /// 3 - Moderate
        /// </summary>
        Moderate = 3,

        /// <summary>
        /// 4 - Minor
        /// </summary>
        Minor = 4
    }

    public static class SeverityEnumExtension
    {
        public static string GetDescription(this SeverityEnum severity)
        {
            var description = string.Empty;

            switch (severity)
            {
                case SeverityEnum.Critical:
                    description = $"{severity.GetHashCode()} - Critical";
                    break;
                case SeverityEnum.Major:
                    description = $"{severity.GetHashCode()} - Major";
                    break;
                case SeverityEnum.Moderate:
                    description = $"{severity.GetHashCode()} - Moderate";
                    break;
                case SeverityEnum.Minor:
                    description = $"{severity.GetHashCode()} - Minor";
                    break;
            }

            return description;
        }
    }
}
