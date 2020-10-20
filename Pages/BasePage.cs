using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UnitTestProject.Utilities;

namespace UnitTestProject.Pages
{
    public abstract class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }
    }
}