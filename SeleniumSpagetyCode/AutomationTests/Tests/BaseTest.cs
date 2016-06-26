using System;
using AutomationTests.Constants;
using AutomationTests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetup()
        {
            try
            {
                Driver = new ChromeDriver();
                PropertiesCollection.Driver = Driver;

                Driver
                    .Manage()
                    .Timeouts()
                    .ImplicitlyWait(new TimeSpan(0, 0, AutomationTestsConstants.OperationTimeoutInSeconds));

                Driver
                    .Manage()
                    .Window
                    .Maximize();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
            if (Driver != null)
            {
                Driver.Close();
                Driver.Dispose();
            }
        }
    }
}