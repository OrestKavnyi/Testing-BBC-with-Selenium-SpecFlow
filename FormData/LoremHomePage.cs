using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using UnitTestProject.Pages;

namespace UnitTestProject.FormData
{
    public class LoremHomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        private IWebElement startTextCheckbox;

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        private IWebElement generateTextButton;

        public LoremHomePage UncheckStartText()
        {
            if (startTextCheckbox.Selected)
                startTextCheckbox.Click();
            return this;
        }
        public void ClickGenerate()
        {
            generateTextButton.Click();
        }
    }
}
