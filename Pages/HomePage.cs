using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace UnitTestProject.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/news']")]
        private IWebElement newsLink;

        [FindsBy(How = How.XPath, Using = "//a[@href='/sport']")]
        private IWebElement sportLink;

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement searchBar;

        public HomePage() { }

        public void GoToNewsPage()
        {
            newsLink.Click();
        }
        public void GoToSportPage()
        {
            sportLink.Click();
        }
        public void SearchFor(string keyword)
        {
            searchBar.SendKeys(keyword + Keys.Enter);
        }
    }
}