using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using UnitTestProject.Utilities;

namespace UnitTestProject.Pages
{
    class FootballPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'sport-navigation')]/a[@*='Scores & Fixtures']")]
        private IWebElement scoresAndFicturesLink;

        public FootballPage() { }

        public void GoToScoresAndFixturesPage()
        {
            scoresAndFicturesLink.Click();
            Wait.WaitForPageReadyState(10);
        }
    }
}
