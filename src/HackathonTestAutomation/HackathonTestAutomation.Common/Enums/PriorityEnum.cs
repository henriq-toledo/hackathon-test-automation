namespace HackathonTestAutomation.Common.Enums
{
    /// <summary>
    /// The <c>PriorityEnum</c> enum represents the priority of a defect
    /// </summary>
    public enum PriorityEnum
    {
        /// <summary>
        /// 1 - High
        /// </summary>
        High = 1,

        /// <summary>
        /// 2 - Medium
        /// </summary>
        Medium = 2,

        /// <summary>
        /// 3 - Low
        /// </summary>
        Low = 3
    }

    /// <summary>
    /// The <c>PriorityEnumExtension</c> class is the extension class from the <c>PriorityEnum</c> enum
    /// </summary>
    public static class PriorityEnumExtension
    {
        /// <summary>
        /// Gets the enum value description
        /// </summary>
        /// <param name="priority">The priority</param>
        /// <returns>The enum value description</returns>
        public static string GetDescription(this PriorityEnum priority)
        {
            var description = string.Empty;

            switch (priority)
            {
                case PriorityEnum.High:
                    description = $"{priority.GetHashCode()} - High";
                    break;
                case PriorityEnum.Medium:
                    description = $"{priority.GetHashCode()} - Medium";
                    break;
                case PriorityEnum.Low:
                    description = $"{priority.GetHashCode()} - Low";
                    break;
            }

            return description;
        }
    }
}
