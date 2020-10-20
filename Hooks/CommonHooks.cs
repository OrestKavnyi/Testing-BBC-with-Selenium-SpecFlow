using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UnitTestProject.Utilities;

namespace UnitTestProject.Hooks
{
    [Binding]
    public sealed class CommonHooks
    {
        public static string HOME_URL => "https://www.bbc.com";

        [BeforeScenario(Order = 1)]
        public void SetUp()
        {
            WebDriver.Driver.Manage().Window.Maximize();
            WebDriver.Driver.Navigate().GoToUrl(HOME_URL);
            Wait.ImplicitlyWait(10);
        }

        [AfterScenario]
        public void CleanUp()
        {
            WebDriver.Quit();
        }
    }
}