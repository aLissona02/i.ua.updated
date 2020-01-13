using OpenQA.Selenium;

namespace i.ua.DOM.Framework
{
    class DriverOperations
    {
        private IWebDriver driver;

        public DriverOperations(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void DriverLaunch(string url)
        { 
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }

        public void DriverStop(IWebDriver driver)
        {
            driver.Close();
        }
    }
}
