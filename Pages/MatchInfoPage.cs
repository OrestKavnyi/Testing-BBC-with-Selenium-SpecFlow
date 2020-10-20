using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject.PageElements;
using UnitTestProject.Utilities;

namespace UnitTestProject.Pages
{
    class MatchInfoPage : BasePage
    {
        public MatchInfoPage() { }

        public MatchInfo GetMatchInfo()
        {
            IList<IWebElement> teams = WebDriver.Driver.FindElements(By.XPath(
                                       "//span[contains(@class,'team')]//span[contains(@class,'full-team-name')]"));
            IList<IWebElement> score = WebDriver.Driver.FindElements(By.XPath(
                                       "//span[contains(@class,'team')]//span[contains(@class,'number')]"));

            return new MatchInfo(teams.ElementAt(0).Text, teams.ElementAt(1).Text,
                                 int.Parse(score.ElementAt(0).Text), int.Parse(score.ElementAt(1).Text));   
        }
    }
}
