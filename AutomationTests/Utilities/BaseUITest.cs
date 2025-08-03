using NUnit.Framework;
using OpenQA.Selenium;
using AutomationTests.Utilities;

namespace AutomationTests
{
    public class BaseUITest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void BaseSetup()
        {
            Driver = DriverFactory.CreateDriver();
            Driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
        }

        [TearDown]
        public void BaseTeardown()
        {
            Driver.Quit();
        }
    }
}
