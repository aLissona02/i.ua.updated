using OpenQA.Selenium;

namespace i.ua.DOM.Framework.TestCases
{
    class LoginPage
    {
         protected IWebDriver driver;

        private IWebElement loginElement => driver.FindElement(By.Name("login"));
        private IWebElement passwordElement => driver.FindElement(By.Name("pass"));

        public LoginPage(IWebDriver driver)

        {
            this.driver = driver;
        }

        public void EnterLogin(string login)
        {
            loginElement.Click();
            loginElement.SendKeys(login); 
        }

        public void EnterPassword(string password)
        {
            passwordElement.Click();
            passwordElement.SendKeys(password + Keys.Enter);
        }

    }
}

