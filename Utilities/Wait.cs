using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject.Utilities
{
    public static class Wait
    {
        public static void ImplicitlyWait(double timeout)
        {
            WebDriver.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
        public static void WaitForPageReadyState(double timeout)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(drv => (drv as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public static void WaitUnillDocumentIsReady(double timeout)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(timeout));
            bool jQueryIsDefined = (bool)(WebDriver.Driver as IJavaScriptExecutor).ExecuteScript("return window.jQuery != undefined");
            if (jQueryIsDefined)
            {
                Func<IWebDriver, bool> readyCondition = drv => (bool)(drv as IJavaScriptExecutor).
                                                        ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0)");
                wait.Until(readyCondition);
            }
            else
                wait.Until(drv => (bool)(drv as IJavaScriptExecutor).ExecuteScript("return document.readyState == 'complete'"));
        }
        public static IList<IWebElement> WaitForElementsToBeVisible(By by, double timeout)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(drv => drv.FindElements(by));
        }
        public static bool ElementExists(By by, out IWebElement element)
        {
            ImplicitlyWait(0);
            element = WebDriver.Driver.FindElements(by).FirstOrDefault();
            ImplicitlyWait(10);
            return element != null;
        }
    }
}