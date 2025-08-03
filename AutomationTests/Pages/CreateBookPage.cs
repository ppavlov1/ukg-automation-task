using OpenQA.Selenium;
using AutomationTests.Utilities;
using AutomationTests.Pages.Components;

namespace AutomationTests.Pages
{
    public class CreateBookPage
    {
        private readonly IWebDriver _driver;

        public CreateBookPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver);
        }
        public Header Header { get; }

        private By PageIdentifier => By.XPath("//h2[text()='Create']");
        private IWebElement NameInput => _driver.FindElement(By.Id("Name"));
        private IWebElement AuthorInput => _driver.FindElement(By.Id("Author"));
        private IWebElement GenreInput => _driver.FindElement(By.Id("Genre"));
        private IWebElement QuantityInput => _driver.FindElement(By.Id("Quontity"));
        private IWebElement CreateButton => _driver.FindElement(By.XPath("//input[@value='Create']"));

        public CreateBookPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public CreateBookPage EnterBookDetails(string name, string author, string genre, string quantity)
        {
            NameInput.Clear(); NameInput.SendKeys(name);
            AuthorInput.Clear(); AuthorInput.SendKeys(author);
            GenreInput.Clear(); GenreInput.SendKeys(genre);
            QuantityInput.Clear(); QuantityInput.SendKeys(quantity);
            return this;
        }

        public BooksPage Submit()
        {
            CreateButton.Click();
            return new BooksPage(_driver);
        }
    }
}
