using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i.ua.DOM.Framework
{
    class DriverOperations
    {
        private IWebDriver driver;
        public DriverOperations(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void driverLaunch(string url)
        { 
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }
        public void driverStop(IWebDriver driver)
        {
            driver.Close();
        }
    }
}
