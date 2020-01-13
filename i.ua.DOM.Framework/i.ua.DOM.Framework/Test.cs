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
        public void TestPerform()
        {
            var login = ConfigurationManager.AppSettings.Get("login");
            var password = ConfigurationManager.AppSettings.Get("pass");
            var textTo = ConfigurationManager.AppSettings["textTo"];
            var textMess = ConfigurationManager.AppSettings["textMessage"];
            var editedFieldTo = ConfigurationManager.AppSettings["textToEdited"];
            var editedFieldSubject = ConfigurationManager.AppSettings["textSubjectEdited"];
            var editedFieldText = ConfigurationManager.AppSettings["textMessageEdited"];

            LoginPage loginPage = new LoginPage(driver);
            InputMessagesPage inputMessagesPage = new InputMessagesPage(driver);
            MessagePage messagePage = new MessagePage(driver);
            DraftsPage draftsPage = new DraftsPage(driver);

            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);

            inputMessagesPage.CreateMessage();

            messagePage.FillFieldTo(textTo);
            messagePage.FillFieldText(textMess);
            messagePage.SaveMessage();
           
            inputMessagesPage.ClickOnDraftsButton();

            draftsPage.ClickOnLastMessage();
           
            messagePage.EditFieldTo(editedFieldTo);
            messagePage.EditFieldSubject(editedFieldSubject);
            messagePage.EditFieldText(editedFieldText);
            messagePage.SaveMessage();

            inputMessagesPage.ClickOnDraftsButton();

            draftsPage.ClickOnLastMessage();

            var actualFieldTo = messagePage.GetCurrentValueId("to");
            var actualFieldSubject = messagePage.GetCurrentValueName("subject");
            var actualFieldText = messagePage.GetCurrentValueId("text");

            Assert.AreEqual(editedFieldTo, actualFieldTo);
            Assert.AreEqual(editedFieldSubject, actualFieldSubject);
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