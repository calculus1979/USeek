using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USeek.UI.ContactUs;
using USeek.Utils;

namespace USeek.UI._Home
{
    public class HomePage
    {
        private const string HOME_PAGE_URL  = "http://www.useek.com/";
        private const string PAGE_TITLE     = "U•Seek";

        private IWebDriver driver;

        private HomePage(IWebDriver driver)
        {
            Assert.AreEqual(PAGE_TITLE, driver.Title);

            PageFactory.InitElements(driver, this);

            this.driver = driver;
        }

        public static HomePage Navigate(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(HOME_PAGE_URL);

            driver.WaitForDocumentReady();

            return new HomePage(driver);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='siteWrapper']//*[@id='mainNavigation']//a[@href='/contact-us/']")]
        private IWebElement contactUsButton;
        public ContactUsPage ClickContactUsButton()
        {
            contactUsButton.Click();

            driver.WaitForDocumentReady();

            return new ContactUsPage(driver);
        }
    }
}
