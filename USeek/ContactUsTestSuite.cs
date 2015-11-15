using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using USeek.UI._Home;
using USeek.UI.ContactUs;
using System.Collections.Generic;
using USeek.Verifiers;
using USeek.Verifiers.ContactUs;

namespace USeek
{
    [TestClass]
    public class ContactUsTestSuite
    {
        private IWebDriver  driver      = null;
        private HomePage    homePage    = null;


        [TestInitialize]
        public void Setup()
        {
            driver      = new FirefoxDriver();
            homePage    = HomePage.Navigate(driver);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }

        [TestMethod]
        public void AllRequiredFieldsAreEmpty()
        {
            // Arrange
            var p = new ContactUsParams()
            {
                FirstName       = String.Empty,
                EmailAddress    = String.Empty,
                Message         = String.Empty,

                ErrorMessages   = new List<string>()
                {
                    "Your form has encountered a problem. Please scroll down to review.",
                    "Name is required.",
                    "Email Address is required.",
                    "Subject is required.",
                    "Message is required.",
                    "Your form has encountered a problem. Please scroll up to review."
                }
            };

            // Act
            var contactUsPage = homePage
                .ClickContactUsButton()
                .ClickContactUsButton()
                .SetFields(p)
                .ClickSubmitButton();

            // Assert
            var verifiers = new List<IVerify>()
            {
                new ContactUsVerifier(contactUsPage, p)
            };

            verifiers.ForEach(v => v.Verify());
        }
    }
}
