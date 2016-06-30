using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class ChooseAnAccountPageModel:PageModel
    {
        [FindsBy(How = How.Id, Using = "signout")]
        public IWebElement SignOut { get; set; }
    }
}