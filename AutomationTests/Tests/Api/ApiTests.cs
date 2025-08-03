using AutomationTests.Models;
using AutomationTests.Services;
using NUnit.Framework;
using System.Diagnostics;
using System.Net;

namespace AutomationTests.Tests.API
{
    public class ApiTests
    {
        [Test]
        public void TC_USERS_01_GetAllUsers_ShouldReturnSuccess()
        {
            var response = new UsersService().GetAllUsers();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void TC_USERS_02_CreateUser_ShouldReturnNewUser()
        {
            var newUser = User.BuildMock();
            var response = new UsersService().CreateUser(newUser);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void TC_BOOKS_01_GetAllBooks_ShouldReturnSuccess()
        {
            var response = new BooksService().GetAllBooks();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void TC_BOOKS_02_CreateBook_ShouldReturnNewBook()
        {
            var book = Book.BuildMock();
            var response = new BooksService().CreateBook(book);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Data.Name, Is.EqualTo(book.Name));
            Assert.That(response.Data.Author, Is.EqualTo(book.Author));
            Assert.That(response.Data.Genre, Is.EqualTo(book.Genre));
            Assert.That(response.Data.Quontity, Is.EqualTo(book.Quontity));
        }

        [Test]
        public void TC_GETBOOK_01_GetAllBorrowed_ShouldReturnSuccess()
        {
            var response = new GetBookService().GetAllBorrowed();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void TC_GETBOOK_02_BorrowBook_ShouldSucceed()
        {
            var user = new UsersService().GetAllUsers().Data?.FirstOrDefault();
            var book = new BooksService().CreateBook(Book.BuildMock()).Data;

            var borrow = new GetBook
            {
                UserId = user.Id,
                BookId = book.Id
            };

            var response = new GetBookService().BorrowBook(borrow);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Data.UserId, Is.EqualTo(user.Id));
            Assert.That(response.Data.BookId, Is.EqualTo(book.Id));
        }
    }
}
