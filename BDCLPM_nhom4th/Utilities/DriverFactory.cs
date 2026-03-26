using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ParaBankTests.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver InitDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}