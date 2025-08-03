using NUnit.Framework;
using AutomationTests.Pages;
using AutomationTests.Utilities;
using OpenQA.Selenium;

namespace AutomationTests.Tests.UI
{
    public class LoginTests : BaseUITest
    {
        [Test]
        public void TC_LOGIN_01_LoginWithValidCredentials_ShouldRedirectToUsersPage()
        {
            new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername(ConfigHelper.Username)
                .EnterPassword(ConfigHelper.Password)
                .ClickSignIn()
                .WaitUntilPageLoaded();

            Assert.That(Driver.Url, Does.Contain("/Users"), "User was not redirected to the Users page.");
        }

        [Test]
        public void TC_LOGIN_02_LoginWithInvalidPassword_ShouldShowError()
        {
            new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername(ConfigHelper.Username)
                .EnterPassword("wrongPassword")
                .ClickSignIn();

            var errorText = new LoginPage(Driver).GetErrorMessage();
            Assert.That(errorText, Is.EqualTo("The provided credentials are incorrect."), "Error message was not shown correctly.");
        }

        [Test]
        public void TC_LOGIN_03_LoginWithEmptyFields_ShouldShowValidationError()
        {
            new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .EnterUsername("")
                .EnterPassword("")
                .ClickSignIn();

            var errorText = new LoginPage(Driver).GetErrorMessage();
            Assert.That(errorText, Is.EqualTo("The provided credentials are incorrect."), "Expected error message not shown for empty login.");
        }

        [Test]
        public void TC_LOGIN_04_ClickSignUp_ShouldRedirectToSignUpPage()
        {
            new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .ClickSignUp();

            Assert.That(Driver.Url, Does.Contain("/SignUp"), "User was not redirected to the Sign Up page.");
        }

        [Test]
        public void TC_LOGIN_05_ClickForgotPassword_ShouldRedirectToForgotPage()
        {
            new LoginPage(Driver)
                .WaitUntilPageLoaded()
                .ClickForgotPassword();

            Assert.That(Driver.Url, Does.Contain("/Forgot"), "User was not redirected to the Forgot Password page.");
        }
    }
}
