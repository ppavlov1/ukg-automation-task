using OpenQA.Selenium;
using AutomationTests.Utilities;

namespace AutomationTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UsernameField => _driver.FindElement(By.Name("username"));
        private IWebElement PasswordField => _driver.FindElement(By.Name("password"));
        private IWebElement SignInButton => _driver.FindElement(By.XPath("//a[@href='/Users']/div"));
        private IWebElement SignUpButton => _driver.FindElement(By.XPath("//a[@href='/']/div"));
        private IWebElement ForgotPasswordLink => _driver.FindElement(By.LinkText("Here!"));
        private By PageIdentifier => By.XPath("//h1[text()='Library Login']");
        private By ErrorMessageLocator => By.XPath("//*[contains(text(),'The provided credentials are incorrect.')]");

        public LoginPage WaitUntilPageLoaded()
        {
            WebDriverHelper.WaitForElementVisible(PageIdentifier, _driver);
            return this;
        }

        public LoginPage EnterUsername(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            return this;
        }

        public UsersPage ClickSignIn()
        {
            SignInButton.Click();
            return new UsersPage(_driver);
        }

        public LoginPage ClickSignUp()
        {
            SignUpButton.Click();
            return this;
        }

        public LoginPage ClickForgotPassword()
        {
            ForgotPasswordLink.Click();
            return this;
        }

        public string GetErrorMessage()
        {
            WebDriverHelper.WaitForElementVisible(ErrorMessageLocator, _driver);
            return _driver.FindElement(ErrorMessageLocator).Text;
        }

    }
}
