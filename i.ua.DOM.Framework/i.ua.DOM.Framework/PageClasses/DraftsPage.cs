using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i.ua.DOM.Framework.TestCases
{
    class DraftsPage
    {
        protected IWebDriver driver;

         public  DraftsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickOnLastMessage()
        {
            IWebElement lastMessage = driver.FindElement(By.XPath("//div/a/span[@class='frm']"));
            lastMessage.Click();
        }
        
    }
}
