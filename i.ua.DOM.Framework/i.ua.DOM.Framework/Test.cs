using System.Configuration;
using System.Collections.Specialized;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using i.ua.DOM.Framework.TestCases;

namespace i.ua.DOM.Framework
{
  
    public class Test
        
    {
       IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {
            DriverOperations webDriver = new DriverOperations(driver);
            webDriver.driverLaunch("https://www.i.ua/");
        }

        [Test]

        public void testPerform()
        {
            string login = ConfigurationManager.AppSettings.Get("login");
            LoginPage logPageOp = new LoginPage(driver);
            logPageOp.sendLogin(login);
            string password = ConfigurationManager.AppSettings.Get("pass");
            logPageOp.sendPassword(password);

            InputMessagesPage inputPage = new InputMessagesPage(driver);
            inputPage.createMes();

            MessagePage message = new MessagePage(driver);
            string textTo = ConfigurationManager.AppSettings["textTo"];
            message.fieldToFill(textTo);
            string textMess = ConfigurationManager.AppSettings["textMessage"];
            message.fieldTextFill(textMess);
            message.saveMes();
            inputPage.draftsButton();

            DraftsPage drafts = new DraftsPage(driver);
            drafts.clickOnLastMessage();
            string toEdited = ConfigurationManager.AppSettings["textToEdited"];
            message.fieldToEdit(toEdited);
            string subjEdited = ConfigurationManager.AppSettings["textSubjectEdited"];
            message.fieldSubjEdit(subjEdited);
            string textEdited = ConfigurationManager.AppSettings["textMessageEdited"];
            message.fieldTextEdit(textEdited);
            message.saveMes();

            inputPage.draftsButton();
            drafts.clickOnLastMessage();

            string toActual = message.currentValueId("to");
            Assert.AreEqual(toEdited, toActual);

            string subjActual = message.currentValueName("subject");
            Assert.AreEqual(subjEdited, subjActual);

            string textActual = message.currentValueId("text");
            Assert.AreEqual(textEdited, textActual);

        }


        [TearDown]
        public void CleanUp()
        {
            DriverOperations webDriver = new DriverOperations(driver);
            webDriver.driverStop(driver);
        }
    }
}