using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace WEB_Automation_Homework
{
    public class Tests : WebDriver
    {
        private string email = "test_automation@test.com";
        private string password = "testing";

        private SearchProcess searchprocess = new SearchProcess();
        private PurchaseProcess purchaseprocess = new PurchaseProcess();

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(); //
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [Test]
        public void LoginTest()
        {
            DoLogin();
            IWebElement signOut = Driver.FindElement(By.CssSelector("[title='Log me out']")); //taip pat galima su '# header > div.nav > div > div > nav > div:nth-child(2) > a' bet pasirinkau dabartini del lengvesnio iskaitomumo
            Assert.AreEqual("Sign out", signOut.Text, "Error message: this button is not visible on the page");
        }

        [Test]
        public void SearchTest()
        {
            DoLogin();
            searchprocess.PerformSearch();
            IList<IWebElement> blouse_item = Driver.FindElements(By.CssSelector("[title='Blouse']")); // pasirinkau FindElements, nes FindElement ieskant 'neteisingo' item ismeta exception ir testas negali pasibaigti tvarkingai
            Assert.AreNotEqual(blouse_item.Count, 0, "Error message: Item not found");
        }

        [Test]
        public void BuyTest()
        {
            DoLogin();
            searchprocess.PerformSearch();
            IWebElement addToCart_btn = Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default > span"));
            addToCart_btn.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[title=\"Proceed to checkout\"]")));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("document.querySelector('[title=\"Proceed to checkout\"]').click()"); //sis elementas egzistuoja visad taciau nera matomas
            purchaseprocess.PerformPurchase();
            IWebElement orderComplete = Driver.FindElement(By.CssSelector("#center_column > div > p > strong"));
            Assert.AreEqual("Your order on My Store is complete.", orderComplete.Text, "Error message: Order failed");
        }

        public void DoLogin()
        {
            IWebElement signIn_btn = Driver.FindElement(By.ClassName("login"));
            signIn_btn.Click();
            IWebElement email_txt = Driver.FindElement(By.Id("email"));
            email_txt.SendKeys(email);
            IWebElement password_txt = Driver.FindElement(By.Id("passwd"));
            password_txt.SendKeys(password);
            IWebElement loginToAccount_btn = Driver.FindElement(By.CssSelector("#SubmitLogin > span"));
            loginToAccount_btn.Click();
        }
    }
}