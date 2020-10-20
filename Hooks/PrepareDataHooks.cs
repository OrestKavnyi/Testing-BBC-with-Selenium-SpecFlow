using System;
using TechTalk.SpecFlow;
using UnitTestProject.FormData;
using UnitTestProject.Utilities;

namespace UnitTestProject.Hooks
{
    [Binding]
    public sealed class PrepareDataHooks
    {
        public static string GENERATOR_URL = "https://www.lipsum.com/";

        [BeforeFeature(Order = 0), Scope(Tag = "SubmitQuestionToBbc")]
        public static void PrepareData()
        {
            WebDriver.Driver.Manage().Window.Maximize();
            WebDriver.Driver.Navigate().GoToUrl(GENERATOR_URL);
            Wait.ImplicitlyWait(20);
            DataGenerator.GenerateData();
            CleanUp();
        }
        private static void CleanUp()
        {
            WebDriver.Quit();
        }
    }
}