using OpenQA.Selenium;

namespace i.ua.DOM.Framework.TestCases
{
    class DraftsPage
    {
        protected IWebDriver driver;

        private IWebElement lastMessage => driver.FindElement(By.XPath("//div/a/span[@class='frm']"));


        public  DraftsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public  void ClickOnLastMessage()
        {  
            lastMessage.Click();
        }
        
    }
}
