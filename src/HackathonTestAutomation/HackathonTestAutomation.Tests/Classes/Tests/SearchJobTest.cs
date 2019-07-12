using HackathonTestAutomation.Common.Classes.Attributes;
using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.Tests.Classes.Asserts;
using HackathonTestAutomation.Tests.Classes.Defaults;
using HackathonTestAutomation.Tests.Classes.Entities;
using HackathonTestAutomation.Tests.Classes.Helpers.Forms;
using HackathonTestAutomation.Tests.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackathonTestAutomation.Tests.Classes.Tests
{
    [TestClass]
    public class SearchJobTest : BaseTest
    {
        [TestMethod]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The search should return the 248472BR-PT job id information.")]
        public void JobShouldBeShown()
        {
            // Arrange
            var jobs = new JobResult[] { };            
            var expectedJob = JobResultDefault.InternPortuguese;
            
            // Act
            SearchJobFormHelper
                .Open()
                .ExperienceLevel.SetValue(ExperienceLevelEnum.Intern)
                .JobCategory.SetValue(JobCategoryEnum.Other)
                .JobCountry.SetValue(JobCountryEnum.Brazil)
                .KeyWordSearch.SetValue(expectedJob.JobId)
                .SearchButton.Click()
                .JobResults.GetValue(out jobs);

            var actualJob = jobs[0];

            // Assert
            Assert.AreEqual<int>(expected: 1, actual: jobs.Length,
                message: $"The return job should be one but returned {jobs.Length}.");

            JobResultAssert.AssertJobResult(expected: expectedJob, actual: actualJob);
        }

        [TestMethod]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The search should return all the BTPs jobs to Brazil.")]
        public void AllSearchedJobsShouldBeFound()
        {
            // Arrange
            var actualJobs = new JobResult[] { };
            var expectedJobs = new JobResult[]
            {
                JobResultDefault.InternInclusivePortuguese,
                JobResultDefault.InternPortuguese,
                JobResultDefault.InternInclusiveEnglish,
                JobResultDefault.InternEnglish                
            };

            // Act
            SearchJobFormHelper
                .Open()
                .ExperienceLevel.SetValue(ExperienceLevelEnum.Intern)
                .JobCategory.SetValue(JobCategoryEnum.Other)
                .JobCountry.SetValue(JobCountryEnum.Brazil)
                .KeyWordSearch.SetValue("btp")
                .SearchButton.Click()
                .JobResults.GetValue(out actualJobs);

            // Assert
            JobResultAssert.AssertJobResult(expectedJobs, actualJobs);
        }

        [TestMethod]
        [Defect(PriorityEnum.Medium, SeverityEnum.Major, description: "The invalid job id should not be found.")]
        public void JobShouldNotBeFound()
        {
            // Arrange
            var jobs = new JobResult[] { };
            var invalidJobId = "000000BR-PT";
            string actualNoJobMessage;
            var expectedNoJobMessage = "There are no jobs available with this search criteria. Please click here to begin a new search.";

            // Act
            SearchJobFormHelper
                .Open()
                .ExperienceLevel.SetValue(ExperienceLevelEnum.None)
                .JobCategory.SetValue(JobCategoryEnum.None)
                .JobCountry.SetValue(JobCountryEnum.None)
                .KeyWordSearch.SetValue(invalidJobId)
                .SearchButton.Click()
                .JobResults.GetValue(out jobs)
                .NoJobsMessage.GetValue(out actualNoJobMessage);

            // Assert
            Assert.AreEqual<int>(expected: 0, actual: jobs.Length,
                message: $"The return job should be one but returned {jobs.Length}.");

            Assert.AreEqual<string>(expected: expectedNoJobMessage, actual: actualNoJobMessage, 
                message: $"When there is no jobs the message '{expectedNoJobMessage}' should be shown.");
        }
    }
}
