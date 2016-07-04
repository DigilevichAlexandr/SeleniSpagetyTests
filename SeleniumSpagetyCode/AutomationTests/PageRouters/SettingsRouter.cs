using System.Threading;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.PageModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTests.PageRouters
{
    public class SettingsRouter
    {
        private IWebDriver _driver;

        private SettingsPageModel _settingsPageModel;

        public SettingsRouter()
        {
            _driver = PropertiesCollection.Driver;
            _settingsPageModel = new SettingsPageModel();
        }

        public void NavigateForwarding()
        {
            _driver.Navigate().GoToUrl(AutomationTestsConstants.ForwardingUrl);
        }

        public void SetSignature(string signatureText)
        {
            _settingsPageModel.Signature.Click();
            _settingsPageModel.Signature.SendKeys(Keys.Control+"a");
            Thread.Sleep(2000);
            _settingsPageModel.Signature.SendKeys(AutomationTestsConstants.SignatureText);
            Thread.Sleep(2000);
            _settingsPageModel.SaveChangesButton.Click();
            Thread.Sleep(5000);
        }

        public void SetVacation(string date,string text)
        {
            _settingsPageModel.VacationOnOption.Click();
            _settingsPageModel.VacationSubjectInput.Clear();
            _settingsPageModel.VacationSubjectInput.SendKeys(AutomationTestsConstants.VacationDate);
            _settingsPageModel.VacationTextInput.SendKeys(Keys.Control+"a");
            _settingsPageModel.VacationTextInput.SendKeys(AutomationTestsConstants.VacationText);
            _settingsPageModel.SaveChangesButton.Click();
            Thread.Sleep(5000);
        }
    }
}