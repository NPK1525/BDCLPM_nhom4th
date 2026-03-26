using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using ParaBankTests.Utilities;

namespace ParaBankTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver? driver;

        // Mở Chrome 1 lần cho cả test class
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = DriverFactory.InitDriver();
        }

        // Reset cookies + về trang chủ trước mỗi test
        [SetUp]
        public void SetUp()
        {
            driver!.Manage().Cookies.DeleteAllCookies();
        }

        // Chụp screenshot nếu test fail
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            }
        }

        // Đóng Chrome 1 lần sau khi chạy xong toàn bộ test class
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
