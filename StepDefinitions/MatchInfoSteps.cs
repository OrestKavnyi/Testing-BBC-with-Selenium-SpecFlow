using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using UnitTestProject.PageElements;
using UnitTestProject.Pages;

namespace UnitTestProject.StepDefinitions
{
    public class Match
    {
        public MatchInfo MatchInfo { get; set; }
    }
    [Binding]
    public class MatchInfoSteps
    {
        private readonly Match match;
        public MatchInfoSteps(Match match)
        {
            this.match = match;
        }

        [When(@"i navigate to scoreboard '(.*)' '(.*)'")]
        public void WhenINavigateToScoreboard(string championship, string month)
        {
            new HomePage().GoToSportPage();
            new SportPage().DismissSignInPopup().GoToFootballPage();
            new FootballPage().GoToScoresAndFixturesPage();
            new ScoresFixturesPage().SearchFor(championship);
            new ChampionshipPage().SelectMonth(month);
        }

        [When(@"i get to a particular match page '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenIGetToAParticularMatchPage(string team1, string team2, int score1, int score2)
        {
            match.MatchInfo = new MatchInfo(team1, team2, score1, score2);
            var actualMatchInfo = new ChampionshipPage().ScoreBoard.GetMatchInfo(match.MatchInfo.GetTeams);
            Assert.AreEqual(match.MatchInfo, actualMatchInfo);
            new ChampionshipPage().GoToMatchInfoPage();
        }

        [Then(@"it should display same match info")]
        public void ThenItShouldDisplaySameMatchInfo()
        {
            Assert.AreEqual(match.MatchInfo, new MatchInfoPage().GetMatchInfo());
        }
    }
}