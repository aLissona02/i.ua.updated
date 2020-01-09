using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i.ua.DOM.Framework.TestCases
{
    class InputMessagesPage
    {
        protected IWebDriver driver;

        public InputMessagesPage(IWebDriver driver)

        {
            this.driver = driver;
        }
        public void createMes()
        {
            IWebElement createBut = driver.FindElement(By.ClassName("Left"));
            createBut.Click();
        }

        public void draftsButton()
        {
            IWebElement draftsBut = driver.FindElement(By.XPath("//a[text()=' Чернетки']"));
            draftsBut.Click();
        }
    }
}
