using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject.Pages;
using UnitTestProject.Utilities;

namespace UnitTestProject.PageElements
{
    public sealed class Form
    {
        private By by;
        private IWebElement formElement;
        public void FillForm(Dictionary<string, string> values)
        {
            foreach (var pair in values)
            {
                by = By.XPath($"//*[contains(@placeholder, \"{pair.Key}\")]");
                if (Wait.ElementExists(by, out formElement))
                {
                    if (pair.Value != string.Empty)
                        formElement.SendKeys(pair.Value);
                    continue;
                }

                by = By.XPath($"//*[contains(text(),\"{pair.Key}\")]/ancestor::label/input");
                if (Wait.ElementExists(by, out formElement))
                {
                    if (pair.Value.ToUpper() == "TRUE")
                        formElement.Click();
                    //continue;
                }
            }
            WebDriver.Driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
        }
    }
}