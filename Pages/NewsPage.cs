using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UnitTestProject.Utilities;


namespace UnitTestProject.Pages
{
    public class NewsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'menuitem-container')]//a[span='Coronavirus']")]
        private IWebElement coronavirusLink;

        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'menuitem-container')]//a[span='Entertainment & Arts']")]
        private IWebElement enterteinmentLink; //added

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//h3[contains(@class,'title')]")]
        private IWebElement mainArticle;
        public string MainArticleTitle
        { 
            get { return mainArticle.Text; }
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//a[contains(@class,'section')]/span")]
        private  IWebElement mainArticleCategory;
        public string MainArticleCategory
        {
            get { return mainArticleCategory.Text; }
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@data-entityid, 'top-stories')]//h3[contains(@class,'heading')]")]
        private IList<IWebElement> secondaryArticles;
        public IEnumerable<string> SecondaryArticlesTitles
        {
            get
            {
                foreach (var article in secondaryArticles)
                {
                    if (article.Displayed)
                        yield return article.Text;
                }
            }
        }

        public NewsPage() { }

        public NewsPage DismissSignInPopup()
        {
            Wait.WaitForElementsToBeVisible(By.XPath("//div[@id='sign_in']"), 20);
            WebDriver.Driver.FindElement(By.XPath("//button[@class='sign_in-exit']")).Click();
            return this;
        }

        public void GoToCoronavirusPage()
        {
            coronavirusLink.Click();
        }

        public void GoToEntertainmentAndArtsPage()
        {
            enterteinmentLink.Click();
        }//added
    }
}