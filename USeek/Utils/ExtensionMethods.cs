using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USeek.Utils
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// This extension method is a wrapper to SendKeys(). It will only send keys when the 
        /// text is NOT null.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetText(this IWebElement control, string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return;
            }

            control.SendKeys(text);
        }

        /// <summary>
        /// This extension method is used by the IWebdriver to wait for the document ready state.
        /// the default timeout is 30 seconds.
        /// </summary>
        /// <param name="driver"></param>
        public static void WaitForDocumentReady(this IWebDriver driver)
        {
            WaitForDocumentReady(driver, 30000);
        }

        /// <summary>
        /// This extension method is used by the IWebdriver to wait for the document ready state.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="milliseconds"></param>
        public static void WaitForDocumentReady(this IWebDriver driver, int milliseconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliseconds));
            wait.Until(x => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
