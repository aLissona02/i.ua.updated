using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using i.ua.DOM.Framework.TestCases;

namespace i.ua.DOM.Framework
{

    public class TestExecution
        
    {
       IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {
            DriverOperations webDriver = new DriverOperations(driver);
            webDriver.DriverLaunch("https://www.i.ua/");
        }

        [Test]

        public void testPerform()
        {
            string login = ConfigurationManager.AppSettings.Get("login");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterLogin(login);
            string password = ConfigurationManager.AppSettings.Get("pass");
            loginPage.EnterPassword(password);

            InputMessagesPage inputMessagesPage = new InputMessagesPage(driver);
            inputMessagesPage.CreateMessage();

            MessagePage messagePage = new MessagePage(driver);
            string textTo = ConfigurationManager.AppSettings["textTo"];
            messagePage.FillFieldTo(textTo);
            string textMess = ConfigurationManager.AppSettings["textMessage"];
            messagePage.FillFieldText(textMess);
            messagePage.SaveMessage();
            inputMessagesPage.ClickOnDraftsButton();

            DraftsPage draftsPage = new DraftsPage(driver);
            draftsPage.ClickOnLastMessage();
            string editedFieldTo = ConfigurationManager.AppSettings["textToEdited"];
            messagePage.EditFieldTo(editedFieldTo);
            string editedFieldSubject = ConfigurationManager.AppSettings["textSubjectEdited"];
            messagePage.EditFieldSubject(editedFieldSubject);
            string editedFieldText = ConfigurationManager.AppSettings["textMessageEdited"];
            messagePage.EditFieldText(editedFieldText);
            messagePage.SaveMessage();

            inputMessagesPage.ClickOnDraftsButton();
            draftsPage.ClickOnLastMessage();

            string actualFieldTo = messagePage.GetCurrentValueId("to");
            Assert.AreEqual(editedFieldTo, actualFieldTo);

            string actualFieldSubject = messagePage.GetCurrentValueName("subject");
            Assert.AreEqual(editedFieldSubject, actualFieldSubject);

            string actualFieldText = messagePage.GetCurrentValueId("text");
            Assert.AreEqual(editedFieldText, actualFieldText);

        }


        [TearDown]
        public void CleanUp()
        {
            DriverOperations webDriver = new DriverOperations(driver);
            webDriver.DriverStop(driver);
        }
    }
}