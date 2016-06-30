using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels.Settings
{
    class ForwardingPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "//input[@type='button'][@act='add']")]
        public IWebElement AddForwardingAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']/div[2]/div/input")]
        public IWebElement ForwardingAddressInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@name='next']")]
        public IWebElement ForwardingNextButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@value='Proceed']")]
        public IWebElement ProceedButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@name='ok']")]
        public IWebElement ForwardingOkButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[4][starts-with(@href,'https://mail-settings.google.com/mail/')]")]
        public IWebElement ForwardingAcceptLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@value='Confirm']")]
        public IWebElement ForwardingConfirmButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='sx_em']")]
        public IWebElement ForwardACopyOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@guidedhelpid='save_changes_button']")]
        public IWebElement ForwardingSaveChangesButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//tr[4]/td/div/button[2]")]
        public IWebElement CancelButton { get; set; }
    }
}
