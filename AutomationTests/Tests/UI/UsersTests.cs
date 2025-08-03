using NUnit.Framework;
using AutomationTests.Pages;
using AutomationTests.Utilities;

namespace AutomationTests.Tests.UI
{
    public class UsersTests : BaseUITest
    {
        [Test]
        public void TC_USERS_01_ViewUsersList_ShouldDisplayUserTable()
        {
            var usersPage = new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername(ConfigHelper.Username)
                .EnterPassword(ConfigHelper.Password)
                .ClickSignIn()
                .WaitUntilPageLoaded();

            Assert.That(usersPage.IsUserTableVisible(), Is.True, "Users table is not visible on the page.");
        }

        [Test]
        public void TC_USERS_02_CreateNewUser_WithValidName_ShouldBeListedInUsersTable()
        {
            string uniqueName = "User_" + DateTime.Now.Ticks;

            var usersPage = new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername(ConfigHelper.Username)
                .EnterPassword(ConfigHelper.Password)
                .ClickSignIn()
                .WaitUntilPageLoaded()
                .ClickCreateNew()
                .WaitUntilPageLoaded()
                .EnterName(uniqueName)
                .Submit()
                .WaitUntilPageLoaded();

            Assert.That(usersPage.IsUserListed(uniqueName), Is.True, $"User '{uniqueName}' was not found in the users table.");
        }
    }
}
