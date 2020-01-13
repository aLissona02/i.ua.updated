using OpenQA.Selenium;

namespace i.ua.DOM.Framework.TestCases
{
    class MessagePage
    {
        protected IWebDriver driver;

        private IWebElement fieldTo => driver.FindElement(By.XPath("//textarea[@id='to']"));
        private IWebElement fieldText => driver.FindElement(By.XPath("//textarea[@id='text']"));
        private IWebElement fieldSubject => driver.FindElement(By.XPath("//div[@class='field_value']//span[@class= 'field']//input[@name='subject']"));
        private IWebElement saveButton => driver.FindElement(By.Name("save_in_drafts"));

        public MessagePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillFieldTo(string textTo)
        {
            fieldTo.SendKeys(textTo);
        }
        public void EditFieldTo(string textToEdited)
        {
            fieldTo.Clear();
            fieldTo.SendKeys(textToEdited);
        }

        public void FillFieldText(string textMessage)
        {
            fieldText.SendKeys(textMessage);
        }
        public void EditFieldText(string textMessageEdited)
        {
            fieldText.Clear();
            fieldText.SendKeys(textMessageEdited);
        }

        public void FillFieldSubject(string textSubject)
        {
            fieldSubject.SendKeys(textSubject);
        }
        public void EditFieldSubject(string textSubjectEdited)
        {
            fieldSubject.Clear();
            fieldSubject.SendKeys(textSubjectEdited);
        }

        public void SaveMessage()
        {
            saveButton.Click();
        }
        
        public string GetCurrentValueId(string path)
        {
           string value =  driver.FindElement(By.Id(path)).GetAttribute("innerHTML");
            return value;
        }
        public string GetCurrentValueName(string path)
        {
            string value = driver.FindElement(By.Name(path)).GetAttribute("value");
            return value;
        }

    }
}
