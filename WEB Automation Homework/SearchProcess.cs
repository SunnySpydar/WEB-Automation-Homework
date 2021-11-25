using OpenQA.Selenium;

namespace WEB_Automation_Homework
{
    class SearchProcess : WebDriver
    {
        private IWebElement GetSearchField() { return Driver.FindElement(By.Id("search_query_top")); }
        private IWebElement GetSearchButton() { return Driver.FindElement(By.CssSelector("#searchbox > button")); }

        public void PerformSearch()

        {
            GetSearchField().SendKeys("blouse");
            GetSearchButton().Click();
        }
    }
}
