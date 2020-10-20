using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using UnitTestProject.Pages;
using UnitTestProject.Utilities;

namespace UnitTestProject.PageElements
{
    public class ScoreBoard
    {
        public MatchInfo GetMatchInfo(MatchInfo.Teams teams)
        {
            IWebElement matchLink = WebDriver.Driver.FindElement(By.XPath(
                                    $"//span[text()='{teams.Team1}']/ancestor::a//span[text()='{teams.Team2}']/ancestor::a"));
            ChampionshipPage.CurrentMatch = matchLink;

            string score1 = matchLink.FindElement(By.XPath(
                            $".//span[text()='{teams.Team1}']/ancestor::span[contains(@class,'team--home')]//span[contains(@class,'number')]")).Text;
            string score2 = matchLink.FindElement(By.XPath(
                            $".//span[text()='{teams.Team2}']/ancestor::span[contains(@class,'team--away')]//span[contains(@class,'number')]")).Text;
            Console.WriteLine("team1: " + teams.Team1 + "\t" + "team2: " + teams.Team2);
            Console.WriteLine("score1: " + score1 + "\t" + "score2: " + score2);
            return new MatchInfo(teams, int.Parse(score1), int.Parse(score2));
        }
    }
}