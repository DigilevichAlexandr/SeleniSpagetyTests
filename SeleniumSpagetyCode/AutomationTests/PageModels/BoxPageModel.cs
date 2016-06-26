using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    class BoxPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[text()='COMPOSE']")]
        public IWebElement ComposeButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@name='to']")]
        public IWebElement To { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        public IWebElement Subject { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        public IWebElement MessageBody { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[text()='Send']")]
        public IWebElement SendButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[4]/div[1]/a/span")]
        public IWebElement RoundWithYourLetter { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[4]/div[2]/div[3]/div[2]/a")]
        public IWebElement SignOutButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div[7]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/div")]
        public IWebElement CheckFirstEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[1]/div/div[1]/div[1]/div/div/div[2]/div[2]/div/div")]
        public IWebElement ReportSpamButtom { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[1][@class='G-asx T-I-J3 J-J5-Ji']")]
        public IWebElement More { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Spam')]")]
        public IWebElement Spam { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div[4]/div[1]/div/table/tbody/tr[1]/td[4]/div[2]/span")]
        public IWebElement FirstEmailSender { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div[4]/div[1]/div/table/tbody/tr/td[8]/span/b")]
        public IWebElement FirstEmailDateTime { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#\\3a 2m")]
        public IWebElement Settings { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#ms > div")]
        public IWebElement SettingsOption { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[1]/div[2]/div[2]/div[6]/a")]
        public IWebElement Forwarding { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[2]/div/div/div/div/div[6]/div/table/tbody/tr[1]/td[2]/div/div[2]/input")]
        public IWebElement AddForwardingAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[32]/div[2]/div/input")]
        public IWebElement ForwardingAddressInput { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[32]/div[3]/button[1]")]
        public IWebElement ForwardingNextButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/form/table/tbody/tr/td/input[3]")]
        public IWebElement ProceedButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[32]/div[3]/button")]
        public IWebElement ForwardingOkButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div[7]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[6]/div/div/div/span[1]/b")]
        public IWebElement FirstEmailDiscription { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[2]/div/table/tr/td[1]/div[2]/div[2]/div/div[3]/div/div/div/div/div/div[1]/div[2]/div[7]/div/a[4]")]
        public IWebElement ForwardingAcceptLink { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/table[3]/tbody/tr/td/form/p/input")]
        public IWebElement ForwardingConfirmButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div/div/div/div[6]/div/table/tbody/tr[1]/td[2]/div/div[1]/table[2]/tbody/tr/td[1]/input")]
        public IWebElement ForwardACopyOption { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div/div/div/div[6]/div/table/tbody/tr[4]/td/div/button[1]")]
        public IWebElement ForwardingSaveChangesButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[1]/div/div[2]/div[5]/a")]
        public IWebElement FiltersTab { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div/div/div/div[5]/div/table/tbody/tr[6]/td/span[1]")]
        public IWebElement CreateFilterButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[34]/div/div[2]/div[2]/span[2]/input")]
        public IWebElement FromInput { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[34]/div/div[2]/div[7]/span[1]/input")]
        public IWebElement HasAttachmentOption { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[35]/div/div[2]/div[9]/div[2]")]
        public IWebElement CreateThisSearchFilter { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[40]/div[3]/button[1]")]
        public IWebElement FilterCreateOkButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[27]/div/div[2]/div[4]/div/div[6]/input")]
        public IWebElement DeleteItCheck { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[30]/div/div[2]/div[4]/div/div[8]/input")]
        public IWebElement MarkimportantCheck{ get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[30]/div/div[2]/div[5]/div")]
        public IWebElement CreateFilterPopupButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div/div/div/div[1]/div[3]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/table/tbody/tr[2]/td/div/div/div[4]/table/tbody/tr/td[4]/div/div[1]/div/div/div")]
        public IWebElement AddAttachmentButton { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[3]/div[4]/div[1]/div/table/tbody/tr[1]/td[4]/div[2]/span")]
        public IWebElement FirstMessageSender { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div[7]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[4]/div[2]/span")]
        public IWebElement InboxFirstMessageSender { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#\\3a 70 > a")]
        public IWebElement ThemesTab { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#\\3a 2 > div > div > div > div > div > div > div:nth-child(10) > div > table > tbody > tr > td > div > a")]
        public IWebElement SetThemLink { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"#\3a gc\2e custom-10 > div.a7U")]
        public IWebElement BeachImage { get; set; }
    }
}
