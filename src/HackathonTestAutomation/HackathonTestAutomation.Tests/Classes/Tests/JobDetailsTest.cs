using HackathonTestAutomation.Common.Classes.Attributes;
using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.Tests.Classes.Defaults;
using HackathonTestAutomation.Tests.Classes.Helpers.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackathonTestAutomation.Tests.Classes.Tests
{
    [TestClass]
    public class JobDetailsTest : BaseTest
    {
        [TestMethod]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The search should return the 248472BR-PT job id information.")]
        public void JobDetailsShouldBeShown()
        {
            //Arange
            string state;
            string city;
            string jobTitle;
            string jobCategory;
            string reqId;
                  
            var expectedJob = JobResultDefault.InternPortuguese;
            var jobId = expectedJob.JobId;

            // Act
            JobDetailsFormHelper
                .Open(jobId)
                .State.GetValue(out state)
                .City.GetValue(out city)
                .JobTitle.GetValue(out jobTitle)
                .Category.GetValue(out jobCategory)
                .ReqId.GetValue(out reqId);

            //Assert
            Assert.AreEqual<string>(expected: expectedJob.StateProvinceCounty, actual: state, 
                message: $"The State '{state}' on the Job Details Form does not match with the value '{expectedJob.StateProvinceCounty}' on Search Job Form.");

            Assert.AreEqual<string>(expected: expectedJob.City, actual: city,
                message: $"The City '{city}' on the Job Details Form does not match with the value '{expectedJob.City}' on Search Job Form.");

            Assert.AreEqual<string>(expected: expectedJob.JobTitle, actual: jobTitle,
                message: $"The Job Title '{jobTitle}' on the Job Details Form does not match with the value '{expectedJob.JobTitle}' on Search Job Form.");

            Assert.AreEqual<string>(expected: expectedJob.JobCategory, actual: jobCategory,
                message: $"The Job Category '{jobCategory}' on the Job Details Form does not match with the value '{expectedJob.JobCategory}' on Search Job Form.");

            Assert.AreEqual<string>(expected: expectedJob.JobId, actual: reqId,
                message: $"The Req ID '{reqId}' on the Job Details Form does not match with the value '{expectedJob.JobId}' on Search Job Form.");
        }
    }
}
