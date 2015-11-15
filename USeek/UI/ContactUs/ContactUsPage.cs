using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USeek.Utils;

namespace USeek.UI.ContactUs
{
    public partial class ContactUsPage
    {
        private const string PAGE_TITLE = "Contact Us — U•Seek";

        private IWebDriver driver;

        public ContactUsPage(IWebDriver driver)
        {
            Assert.AreEqual(PAGE_TITLE, driver.Title);

            PageFactory.InitElements(driver, this);

            this.driver = driver;
        }

        #region Buttons
        [FindsBy(How = How.XPath, Using = "//*[@id='page']//span[contains(text(),'Contact Us')]")]
        private IWebElement contactUsButton;
        public ContactUsPage ClickContactUsButton()
        {
            contactUsButton.Click();

            return this;
        }

        [FindsBy(How = How.XPath, Using = "//input[@value='Submit']")]
        private IWebElement submitButton;
        public ContactUsPage ClickSubmitButton()
        {
            submitButton.Click();

            //driver.WaitForDocumentReady();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists((By.XPath("//form/div[@class='field-error']"))));

            return this;
        }
        #endregion Buttons

        #region Fields
        [FindsBy(How = How.XPath, Using = "//input[@name='fname']")]
        private IWebElement firstName;
        public string FirstName
        {
            get
            {
                return firstName.Text;
            }
            set
            {
                firstName.SetText(value);
            }
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='lname']")]
        private IWebElement lastName;
        public string LastName
        {
            get
            {
                return lastName.Text;
            }
            set
            {
                lastName.SetText(value);
            }
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement emailAddress;
        public string EmailAddress
        {
            get
            {
                return emailAddress.Text;
            }
            set
            {
                emailAddress.SetText(value);
            }
        }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Subject')]/../input")]
        private IWebElement subject;
        public string Subject
        {
            get
            {
                return subject.Text;
            }
            set
            {
                subject.SetText(value);
            }
        }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Message')]/../textarea")]
        private IWebElement message;
        public string Message
        {
            get
            {
                return message.Text;
            }
            set
            {
                message.SetText(value);
            }
        }
        #endregion Fields

        #region ErrorFields
        public List<string> ErrorMessages
        {
            get
            {
                var fields = driver.FindElements(By.XPath("//div[@class='field-error']"));

                return fields.Select(f => f.GetAttribute("innerHTML")).ToList();
            }
        }
        #endregion ErrorFields
    }
}