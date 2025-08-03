using OpenQA.Selenium;
using AutomationTests.Utilities;
using AutomationTests.Pages.Components;

namespace AutomationTests.Pages
{
    public class GetBookPage
    {
        private readonly IWebDriver _driver;

        public GetBookPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver);
        }
        public Header Header { get; }

        private By PageIdentifier => By.XPath("//h2[text()='Index']");
        private IWebElement CreateNewButton => _driver.FindElement(By.XPath("//a[@href='/GetBook/Create']"));
        private IWebElement GetBookTable => _driver.FindElement(By.CssSelector("table.table"));

        public GetBookPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public GetBookPage ClickCreateNew()
        {
            CreateNewButton.Click();
            return this;
        }

        public bool IsGetBookTableVisible()
        {
            return GetBookTable.Displayed;
        }
    }
}
