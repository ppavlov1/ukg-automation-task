using NUnit.Framework;
using AutomationTests.Pages;
using AutomationTests.Utilities;

namespace AutomationTests.Tests.UI
{
    public class BooksTests : BaseUITest
    {
        [Test]
        public void TC_BOOKS_01_ViewBooksList_ShouldDisplayBooksTable()
        {
            var booksPage = new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername(ConfigHelper.Username)
                .EnterPassword(ConfigHelper.Password)
                .ClickSignIn()
                .WaitUntilPageLoaded()
                .Header.ClickBooks()
                .WaitUntilPageLoaded();

            Assert.That(booksPage.IsBooksTableVisible(), Is.True, "Books table is not visible on the page.");
        }

        [Test]
        public void TC_BOOKS_02_CreateNewBook_WithValidData_ShouldBeListedInBooksTable()
        {
            string title = "Book_" + DateTime.Now.Ticks;
            string author = "Author_" + DateTime.Now.Ticks;
            string genre = "Genre_" + DateTime.Now.Ticks;
            string quantity = "5";

            var booksPage = new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername(ConfigHelper.Username)
                .EnterPassword(ConfigHelper.Password)
                .ClickSignIn()
                .Header.ClickBooks()
                .WaitUntilPageLoaded()
                .ClickCreateNew()
                .WaitUntilPageLoaded()
                .EnterBookDetails(title, author, genre, quantity)
                .Submit()
                .WaitUntilPageLoaded();

            Assert.That(booksPage.IsBookListed(title, author, genre, quantity), Is.True,
                 $"Book with values [{title}, {author}, {genre}, {quantity}] was not found.");
        }
    }
}
