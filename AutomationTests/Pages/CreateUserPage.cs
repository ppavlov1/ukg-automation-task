using OpenQA.Selenium;
using AutomationTests.Utilities;
using AutomationTests.Pages.Components;

namespace AutomationTests.Pages
{
    public class CreateUserPage
    {
        private readonly IWebDriver _driver;

        public CreateUserPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver);
        }
        public Header Header { get; }

        private By PageIdentifier => By.XPath("//h2[text()='Create']");
        private IWebElement NameInput => _driver.FindElement(By.Id("Name"));
        private IWebElement CreateButton => _driver.FindElement(By.XPath("//input[@value='Create']"));

        public CreateUserPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public CreateUserPage EnterName(string name)
        {
            NameInput.Clear();
            NameInput.SendKeys(name);
            return this;
        }

        public UsersPage Submit()
        {
            CreateButton.Click();
            return new UsersPage(_driver);
        }
    }
}
