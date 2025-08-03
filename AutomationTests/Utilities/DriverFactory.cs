﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTests.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
