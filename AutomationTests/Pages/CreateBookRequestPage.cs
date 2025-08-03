using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationTests.Utilities;
using AutomationTests.Pages.Components;

namespace AutomationTests.Pages
{
    public class CreateBookRequestPage
    {
        private readonly IWebDriver _driver;

        public CreateBookRequestPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver);
        }
        public Header Header { get; }

        private By PageIdentifier => By.XPath("//h2[text()='Create']");
        private SelectElement UserDropdown => new SelectElement(_driver.FindElement(By.Id("UserId")));
        private SelectElement BookDropdown => new SelectElement(_driver.FindElement(By.Id("BookId")));
        private IWebElement CreateButton => _driver.FindElement(By.XPath("//input[@value='Create']"));

        public CreateBookRequestPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public CreateBookRequestPage SelectUser(string user)
        {
            UserDropdown.SelectByText(user);
            return this;
        }

        public CreateBookRequestPage SelectBook(string book)
        {
            BookDropdown.SelectByText(book);
            return this;
        }

        public GetBookPage Submit()
        {
            CreateButton.Click();
            return new GetBookPage(_driver);
        }
    }
}
