using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationTests.Constants;
using AutomationTests.Extentions;

namespace AutomationTests.Helpers
{
    public static class CommonHelper
    {
        public static IWebDriver Driver { get; set; }

        static CommonHelper()
        {
            Driver = PropertiesCollection.Driver;
        }

        public static void NavigateGmail()
        {
            Driver.Navigate().GoToUrl(AutomationTestsConstants.GmailAddres);
        }

        public static string GenerateFile(int megabytes)
        {
            // TO DO
            return string.Empty;
        }
    }

}