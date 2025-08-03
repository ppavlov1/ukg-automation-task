using OpenQA.Selenium;
using AutomationTests.Utilities;
using AutomationTests.Pages.Components;

namespace AutomationTests.Pages
{
    public class BooksPage
    {
        private readonly IWebDriver _driver;

        public BooksPage(IWebDriver driver)
        {
            _driver = driver;
            Header = new Header(_driver); 
        }
        public Header Header { get; }

        private By PageIdentifier => By.XPath("//h2[text()='Index']");
        private IWebElement CreateNewButton => _driver.FindElement(By.XPath("//a[@href='/Books/Create']"));
        private IWebElement BooksTable => _driver.FindElement(By.CssSelector("table.table"));

        public BooksPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public CreateBookPage ClickCreateNew()
        {
            CreateNewButton.Click();
            return new CreateBookPage(_driver);
        }

        public bool IsBooksTableVisible()
        {
            return BooksTable.Displayed;
        }

        public bool IsBookListed(string name, string author, string genre, string quantity)
        {
            var rows = BooksTable.FindElements(By.CssSelector("tbody tr"));

            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td")).ToList();
                if (cells.Count >= 4 &&
                    cells[0].Text.Trim() == name &&
                    cells[1].Text.Trim() == author &&
                    cells[2].Text.Trim() == genre &&
                    cells[3].Text.Trim() == quantity)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
