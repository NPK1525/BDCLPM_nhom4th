using NUnit.Framework;
using ParaBankTests.Pages;
using ParaBankTests.Utilities;

namespace ParaBankTests.Tests
{
    [TestFixture]
    [Category("Smoke")]
    public class LoginTests : BaseTest
    {
        private LoginPage loginPage = null!;
        private AccountOverviewPage accountOverviewPage = null!;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
            loginPage = new LoginPage(driver!);
            accountOverviewPage = new AccountOverviewPage(driver!);
            loginPage.Open();
        }

        // ── Smoke Tests ──────────────────────────────────────────────────────────

        [Test]
        [Description("TC_SM_01: Đăng nhập thành công với tài khoản hợp lệ")]
        public void TC_SM_01_LoginSuccessfully_WithValidCredentials()
        {
            string username = TestDataHelper.Get("validUser", "username");
            string password = TestDataHelper.Get("validUser", "password");

            loginPage.Login(username, password);

            Assert.That(accountOverviewPage.IsAtAccountOverview(), Is.True,
                "Trang Accounts Overview không hiển thị sau khi đăng nhập.");
            Assert.That(accountOverviewPage.IsLogoutVisible(), Is.True,
                "Nút Log Out không hiển thị sau khi đăng nhập.");
        }

        [Test]
        [Description("TC_SM_02: Logout thành công sau khi đăng nhập")]
        public void TC_SM_02_LogoutSuccessfully()
        {
            loginPage.Login(
                TestDataHelper.Get("validUser", "username"),
                TestDataHelper.Get("validUser", "password"));

            Assert.That(accountOverviewPage.IsLogoutVisible(), Is.True);

            accountOverviewPage.Logout();

            Assert.That(loginPage.IsLoginButtonDisplayed(), Is.True,
                "Nút Log In không hiển thị sau khi logout.");
        }

        // ── GUI Tests ─────────────────────────────────────────────────────────────

        [Test]
        [Category("GUI")]
        [Description("TC_GUI_01: Kiểm tra các element trên trang Login hiển thị đúng")]
        public void TC_GUI_01_LoginPageElements_AreDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.IsUsernameInputDisplayed(), Is.True, "Username input không hiển thị.");
                Assert.That(loginPage.IsPasswordInputDisplayed(), Is.True, "Password input không hiển thị.");
                Assert.That(loginPage.IsLoginButtonDisplayed(), Is.True, "Login button không hiển thị.");
                Assert.That(loginPage.IsLoginButtonEnabled(), Is.True, "Login button không được enabled.");
            });
        }

        [Test]
        [Category("GUI")]
        [Description("TC_GUI_02: Textbox username và password nhập được")]
        public void TC_GUI_02_TextboxInputs_AcceptText()
        {
            loginPage.EnterUsername("testuser");
            loginPage.EnterPassword("testpass");

            // Nếu không throw exception thì textbox nhập được
            Assert.Pass("Textbox username và password nhập được bình thường.");
        }

        [Test]
        [Category("GUI")]
        [Description("TC_GUI_03: Thông báo lỗi hiển thị khi đăng nhập sai")]
        public void TC_GUI_03_ErrorMessage_DisplayedOnInvalidLogin()
        {
            loginPage.Login(
                TestDataHelper.Get("invalidUser", "username"),
                TestDataHelper.Get("invalidUser", "password"));

            Assert.That(loginPage.IsErrorDisplayed(), Is.True,
                "Thông báo lỗi không hiển thị khi đăng nhập sai.");
        }

        // ── Functional Tests ──────────────────────────────────────────────────────

        [Test]
        [Category("Functional")]
        [Description("TC_FN_01: Đăng nhập thất bại với mật khẩu sai")]
        public void TC_FN_01_Login_FailsWithWrongPassword()
        {
            loginPage.Login(
                TestDataHelper.Get("validUser", "username"),
                "wrongpassword");

            Assert.That(loginPage.IsErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi đăng nhập với mật khẩu sai.");
        }

        [Test]
        [Category("Functional")]
        [Description("TC_FN_02: Đăng nhập thất bại khi để trống username và password")]
        public void TC_FN_02_Login_FailsWithEmptyCredentials()
        {
            loginPage.ClickLogin();

            Assert.That(loginPage.IsErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi đăng nhập với thông tin trống.");
        }
    }
}
