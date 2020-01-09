using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i.ua.DOM.Framework.TestCases
{
    class LoginPage
    {
         protected IWebDriver driver;

        public LoginPage(IWebDriver driver)

        {
            this.driver = driver;
        }

        public void sendLogin(string log)
        {
            IWebElement loginEl = driver.FindElement(By.Name("login"));
            loginEl.Click();
            loginEl.SendKeys(log); 
        }

        public void sendPassword(string pass)
        {
            IWebElement passwordEl = driver.FindElement(By.Name("pass"));
            passwordEl.Click();
            passwordEl.SendKeys(pass + Keys.Enter);
        }

    }
}

