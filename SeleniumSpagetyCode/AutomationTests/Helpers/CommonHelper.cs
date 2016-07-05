using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

        public static void GenerateFile(string fileName, int megaBytes)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                var user = Environment.UserName;

                byte[] data = new byte[megaBytes * 1024 * 1024];
                Random rng = new Random();
                rng.NextBytes(data);
                File.WriteAllBytes(string.Format("{0}{1}",AutomationTestsConstants.TestFilePath, fileName),data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AcceptPopap()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException) { }
        }
    }

}