using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i.ua.DOM.Framework.TestCases
{
    class MessagePage
    {
        protected IWebDriver driver;

        public MessagePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void fieldToFill(string textTo)
        {
            IWebElement fieldTo = driver.FindElement(By.XPath("//textarea[@id='to']"));
            fieldTo.SendKeys(textTo);
        }
        public void fieldToEdit(string textToEdited)
        {
            IWebElement fieldTo = driver.FindElement(By.XPath("//textarea[@id='to']"));
            fieldTo.Clear();
            fieldTo.SendKeys(textToEdited);
        }

        public void fieldTextFill(string textText)
        {
            IWebElement fieldText = driver.FindElement(By.XPath("//textarea[@id='text']"));
            fieldText.SendKeys(textText);
        }
        public void fieldTextEdit(string textTextEdited)
        {
            IWebElement fieldText = driver.FindElement(By.XPath("//textarea[@id='text']"));
            fieldText.Clear();
            fieldText.SendKeys(textTextEdited);
        }

        public void fieldSubjectFill(string textSubj)
        {
            IWebElement fieldSubj = driver.FindElement(By.XPath("//div[@class='field_value']//span[@class= 'field']//input[@name='subject']"));
            fieldSubj.SendKeys(textSubj);
        }
        public void fieldSubjEdit(string textSubjEdited)
        {
            IWebElement fieldSubj = driver.FindElement(By.XPath("//div[@class='field_value']//span[@class= 'field']//input[@name='subject']"));
            fieldSubj.Clear();
            fieldSubj.SendKeys(textSubjEdited);
        }

        public void saveMes()
        {
            IWebElement saveBut = driver.FindElement(By.Name("save_in_drafts"));
            saveBut.Click();
        }
        
        public string currentValueId(string path)
        {
           string value =  driver.FindElement(By.Id(path)).GetAttribute("innerHTML");
            return value;
        }
        public string currentValueName(string path)
        {
            string value = driver.FindElement(By.Name(path)).GetAttribute("value");
            return value;
        }

    }
}
