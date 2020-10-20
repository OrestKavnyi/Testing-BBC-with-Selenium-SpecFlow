using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject.PageElements;
using UnitTestProject.Utilities;

namespace UnitTestProject.Pages
{
    public class ChampionshipPage : BasePage
    {
        public static IWebElement CurrentMatch { get; set; }
        public ScoreBoard ScoreBoard { get; }

        public ChampionshipPage()
        {
            Wait.WaitForPageReadyState(10);
            ScoreBoard = new ScoreBoard();
        }

        public ChampionshipPage SelectMonth(string month)
        {
            WebDriver.Driver.FindElement(By.XPath($"//a[contains(@class,'timeline')][span='{month.ToUpper()}']")).Click();
            Wait.WaitForPageReadyState(10);
            return this;
        }

        public void GoToMatchInfoPage()
        {
            CurrentMatch?.Click();
        }
    }
}