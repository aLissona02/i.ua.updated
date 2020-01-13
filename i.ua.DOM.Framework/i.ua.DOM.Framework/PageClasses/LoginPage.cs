using OpenQA.Selenium;

namespace i.ua.DOM.Framework.TestCases
{
    class LoginPage
    {
         protected IWebDriver driver;

        private IWebElement loginEl => driver.FindElement(By.Name("login"));
        private IWebElement passwordEl => driver.FindElement(By.Name("pass"));

        public LoginPage(IWebDriver driver)

        {
            this.driver = driver;
        }

        public void EnterLogin(string log)
        {
            loginEl.Click();
            loginEl.SendKeys(log); 
        }

        public void EnterPassword(string pass)
        {
            passwordEl.Click();
            passwordEl.SendKeys(pass + Keys.Enter);
        }

    }
}

