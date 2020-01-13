using OpenQA.Selenium;

namespace i.ua.DOM.Framework.TestCases
{
    class InputMessagesPage
    {
        protected IWebDriver driver;

        private IWebElement createButton => driver.FindElement(By.ClassName("Left"));
        private IWebElement draftsButton => driver.FindElement(By.XPath("//a[text()=' Чернетки']"));

        public InputMessagesPage(IWebDriver driver)

        {
            this.driver = driver;
        }

        public void CreateMessage()
        {
            createButton.Click();
        }

        public void ClickOnDraftsButton()
        {
            draftsButton.Click();
        }
    }
}
