using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UnitTestProject.PageElements;
using UnitTestProject.Utilities;

namespace UnitTestProject.Pages
{
    public class ShareWithBbcNewsPage : BasePage
    {
        public Form Form { get; }
        public By ErrorMessages => By.XPath("//div[@class='input-error-message']");

        public ShareWithBbcNewsPage()
        {
            Wait.WaitForPageReadyState(10);
            Form = new Form();
        }
    }
}