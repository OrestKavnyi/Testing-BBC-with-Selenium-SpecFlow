using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTestProject.Utilities;
using UnitTestProject.Pages;
using UnitTestProject.FormData;
using UnitTestProject.ExtensionMethods;

namespace UnitTestProject.StepDefinitions
{
    public class Message
    {
        public IList<IWebElement> ErrorMessages { get; set; }
    }

    [Binding]
    public class SubmitQuestionToBbcSteps
    {
        private readonly Message message;
        public SubmitQuestionToBbcSteps(Message message)
        {
            this.message = message;
        }

        [Given(@"Home page is open")]
        public void GivenHomePageIsOpen()
        {
            return;
        }

        [When(@"i navigate to Share With Bbc page")]
        public void WhenINavigateToShareWithBbcPage()
        {
            new HomePage().GoToNewsPage();
            new NewsPage().DismissSignInPopup().GoToCoronavirusPage();
            new CoronavirusPage().GoToYourCoronavirusStoriesPage();
            new YourCoronavirusStoryPage().GoToShareWithBbcNewsPage();
        }

/*        [When(@"i submit my question with '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenISubmitMyQuestionWith(string story, string name, string over16, string terms, Table headers)
        {
            var testData = headers.ToDictionary(story, name, over16, terms);
            new ShareWithBbcNewsPage().Form.FillForm(testData);
            
            message.ErrorMessages = Wait.WaitForElementsToBeVisible(new ShareWithBbcNewsPage().ErrorMessages, 10);
        }*/

        [When(@"i submit my question with")]
        public void WhenISubmitMyQuestionWith(Table table)
        {
            var testData = table.ToDictionary();
            new ShareWithBbcNewsPage().Form.FillForm(testData);

            message.ErrorMessages = Wait.WaitForElementsToBeVisible(new ShareWithBbcNewsPage().ErrorMessages, 10);
        }

        [When(@"i submit my question '(.*)'")]
        public void WhenISubmitMyQuestion(string testCase)
        {
            var testData = DataGenerator.GetTestData(testCase);
            new ShareWithBbcNewsPage().Form.FillForm(testData);

            message.ErrorMessages = Wait.WaitForElementsToBeVisible(new ShareWithBbcNewsPage().ErrorMessages, 10);
        }

        [Then(@"error message must be shown")]
        public void ThenErrorMessageMustBeShown()
        {
            Assert.IsTrue(message.ErrorMessages.Any());
        }
    }
}