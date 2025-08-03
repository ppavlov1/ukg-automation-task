using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationTests.Utilities
{
    public static class WebDriverHelper
    {
        public static void WaitForElementVisible(By locator, IWebDriver driver, int timeoutSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element with locator '{locator}' was not visible after {timeoutSeconds} seconds.");
            }
        }

        public static void WaitForElementClickable(IWebElement element, IWebDriver driver, int timeoutSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Element was not clickable after " + timeoutSeconds + " seconds.");
            }
        }

        public static void WaitForElementToDisappear(By locator, IWebDriver driver, int timeoutSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element with locator '{locator}' was still visible after {timeoutSeconds} seconds.");
            }
        }

        public static void WaitForElementToBeDisplayed(IWebElement element, IWebDriver driver, int timeoutSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(driver => element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Element was not displayed after " + timeoutSeconds + " seconds.");
            }
        }
    }
}
