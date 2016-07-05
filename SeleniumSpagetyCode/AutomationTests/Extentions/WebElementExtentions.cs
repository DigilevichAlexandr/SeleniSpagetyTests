using System.Linq;
using OpenQA.Selenium;

namespace AutomationTests.Extentions
{
    public static class WebElementExtentions
    {
        public static string GetBackgroundColor(this IWebElement webElement)
        {
            return webElement
                .GetAttribute("style")
                    .Split(';')[1].Split('#').Last();
        }
    }
}