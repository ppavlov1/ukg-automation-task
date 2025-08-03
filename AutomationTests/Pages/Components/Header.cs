using OpenQA.Selenium;
using AutomationTests.Utilities;

namespace AutomationTests.Pages.Components
{
    public class Header
    {
        private readonly IWebDriver _driver;

        public Header(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UsersLink => _driver.FindElement(By.LinkText("Users"));
        private IWebElement BooksLink => _driver.FindElement(By.LinkText("Books"));
        private IWebElement GetBookLink => _driver.FindElement(By.LinkText("Get a book"));

        private void HandleCookiesBanner()
        {
            var acceptButton = _driver.FindElement(By.XPath(".//button[contains(text(),'Accept')]"));
            if (acceptButton.Displayed)
            {
                acceptButton.Click();
            }
        }

        public UsersPage ClickUsers()
        {
            HandleCookiesBanner();
            WebDriverHelper.WaitForElementClickable(UsersLink, _driver);
            UsersLink.Click();
            return new UsersPage(_driver);
        }

        public BooksPage ClickBooks()
        {
            HandleCookiesBanner();
            WebDriverHelper.WaitForElementClickable(BooksLink, _driver);
            BooksLink.Click();
            return new BooksPage(_driver);
        }

        public GetBookPage ClickGetBook()
        {
            HandleCookiesBanner();
            WebDriverHelper.WaitForElementClickable(GetBookLink, _driver);
            GetBookLink.Click();
            return new GetBookPage(_driver);
        }
    }
}
