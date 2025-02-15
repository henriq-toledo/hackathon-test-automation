﻿using HackathonTestAutomation.Common.Classes.Attributes;
using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.Tests.Classes.Helpers.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackathonTestAutomation.Tests.Classes.Tests
{
    [TestClass]
    public class ConnectCommunityTest : BaseTest
    {
        [TestMethod]
        [Defect(PriorityEnum.High, SeverityEnum.Critical, description: "The required fields if blank should have an error message when click in connect and apply.")]
        public void RequiredFieldsShouldHaveAnErrorMessageWhenNotFilled()
        {
            //Arrange
            string firstNameErrorMessage;
            string lastNameErrorMessage;
            string primaryEmailErrorMessage;

            var expectedMessage = "Esse campo é obrigatório.";
            
            //Act
            ConnectCommunityFormHelper.Open(jobId: "248472BR-PT")
                .ConnectAndApply.Click()
                .FirstName.GetError(out firstNameErrorMessage)
                .LastName.GetError(out lastNameErrorMessage)
                .PrimaryEmail.GetError(out primaryEmailErrorMessage);
            
            //Assert
            Assert.AreEqual<string>(expected: expectedMessage, actual: firstNameErrorMessage,
                message: "The Name required field should have an error message when not filed");

            Assert.AreEqual<string>(expected: expectedMessage, actual: lastNameErrorMessage,
                message: "The Last Name required field should have an error message when not filed");

            Assert.AreEqual<string>(expected: expectedMessage, actual: primaryEmailErrorMessage,
                message: "The Primary e-mail required field should have an error message when not filed");
        }
    }
}
