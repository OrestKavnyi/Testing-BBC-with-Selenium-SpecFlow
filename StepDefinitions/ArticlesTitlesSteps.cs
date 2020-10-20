using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using UnitTestProject.ExtensionMethods;
using UnitTestProject.Pages;

namespace UnitTestProject.StepDefinitions
{
    [Binding]
    public class ArticlesTitlesSteps
    {
        [When(@"i navigate to News page")]
        public void WhenINavigateToNewsPage()
        {
            new HomePage().GoToNewsPage();
            new NewsPage().DismissSignInPopup();
        }
        
        [When(@"i put category name of main article in search bar")]
        public void WhenIPutCategoryNameOfMainArticleInSearchBar()
        {
            new HomePage().SearchFor(new NewsPage().MainArticleCategory);
        }

        [Then(@"main article title should be '(.*)'")]
        public void ThenMainArticleTitleShouldBe(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, new NewsPage().MainArticleTitle);
        }
        
        [Then(@"secondary articles titles should be")]
        public void ThenSecondaryArticlesTitlesShouldBe(Table titles)
        {
            var expectedTitles = titles.ToList();
            var actualTitles = new NewsPage().SecondaryArticlesTitles.ToList();

            for (int i = 0; i < expectedTitles.Count; i++)
                Assert.AreEqual(expectedTitles[i], actualTitles[i]);
        }
        
        [Then(@"title of first found article should be '(.*)'")]
        public void ThenTitleOfFirstFoundArticleShouldBe(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, new SearchResultPage().FirstArticleTitle);
        }
    }
}