using OpenQA.Selenium;

namespace WEB_Automation_Homework
{
    class PurchaseProcess : WebDriver
    {
        private IWebElement GetCheckout_btn() { return Driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium > span")); }
        private IWebElement GetAdditionalInfo_txt() { return Driver.FindElement(By.CssSelector("#ordermsg > textarea")); }
        private IWebElement GetCheckout_btn2() { return Driver.FindElement(By.CssSelector("#center_column > form > p > button")); }
        private IWebElement GetTermsAndCond_btn() { return Driver.FindElement(By.Id("uniform-cgv")); }
        private IWebElement GetCheckout_btn3() { return Driver.FindElement(By.CssSelector("#form > p > button > span")); }
        private IWebElement GetBankWire_btn() { return Driver.FindElement(By.CssSelector("[title='Pay by bank wire']")); }
        private IWebElement GetConfirmOrder_btn() { return Driver.FindElement(By.CssSelector("#cart_navigation > button > span")); }

            public void PerformPurchase()
        { 
            GetCheckout_btn().Click();
            GetAdditionalInfo_txt().SendKeys("It's been a challenge and a pleasure doing this homework :)");
            GetCheckout_btn2().Click();
            GetTermsAndCond_btn().Click();
            GetCheckout_btn3().Click();
            GetBankWire_btn().Click();
            GetConfirmOrder_btn().Click();
        }
    }
}