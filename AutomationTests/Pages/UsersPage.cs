using OpenQA.Selenium;
using AutomationTests.Utilities;
using AutomationTests.Pages.Components;

namespace AutomationTests.Pages
{
    public class UsersPage
    {
        private readonly IWebDriver _driver;

        public UsersPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver);
        }
        public Header Header { get; }

        private By PageIdentifier => By.XPath("//h2[text()='Index']");

        private IWebElement CreateNewButton => _driver.FindElement(By.XPath("//a[@href='/Users/Create']"));
        private IWebElement UsersTable => _driver.FindElement(By.CssSelector("table.table"));
        private List<IWebElement> UserNames => UsersTable.FindElements(By.CssSelector("tbody tr td")).ToList();

        public UsersPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public CreateUserPage ClickCreateNew()
        {
            CreateNewButton.Click();
            return new CreateUserPage(_driver);
        }

        public bool IsUserTableVisible()
        {
            return UsersTable.Displayed;
        }

        public bool IsUserListed(string username)
        {
            return UserNames.Any(cell => cell.Text.Trim() == username);
        }
    }
}
