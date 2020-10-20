using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UnitTestProject.Utilities;

namespace UnitTestProject.Pages
{
    public class CoronavirusPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'menuitem-container')]//span[text()='Your Coronavirus Stories']")]
        private readonly IWebElement yourCoronavirusStoriesLink;
        public CoronavirusPage() { }

        public void GoToYourCoronavirusStoriesPage()
        {
            yourCoronavirusStoriesLink.Click();
        }
    }
}