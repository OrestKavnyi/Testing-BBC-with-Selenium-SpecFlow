using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject.Utilities
{
    public static class WebDriver
    {
        private static IWebDriver driver;
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
            private set { driver = value; }
        }
        public static void Quit()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}