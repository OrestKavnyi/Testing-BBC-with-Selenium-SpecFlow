using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace UnitTestProject.Pages
{
    public class SearchResultPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//p[contains(@class,'Headline')]//span")]
        private readonly IWebElement firstFoundArticle;
        public string FirstArticleTitle
        {
            get { return firstFoundArticle.Text; }
        }
    }
}