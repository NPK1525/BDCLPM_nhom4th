using NUnit.Framework;
using ParaBankTests.Pages;
using ParaBankTests.Utilities;

namespace ParaBankTests.Tests
{
    [TestFixture]
    [Category("Functional")]
    public class TransferFundsTests : BaseTest
    {
        private LoginPage loginPage = null!;
        private AccountOverviewPage accountOverviewPage = null!;
        private TransferFundsPage transferFundsPage = null!;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
            loginPage = new LoginPage(driver!);
            accountOverviewPage = new AccountOverviewPage(driver!);
            transferFundsPage = new TransferFundsPage(driver!);

            // Đăng nhập trước mỗi test
            loginPage.Open();
            loginPage.Login(
                TestDataHelper.Get("validUser", "username"),
                TestDataHelper.Get("validUser", "password"));

            accountOverviewPage.GoToTransferFunds();
        }

        [Test]
        [Description("TC_TF_01: Transfer Funds thành công với số tiền hợp lệ")]
        public void TC_TF_01_TransferFunds_Successfully()
        {
            transferFundsPage.Transfer(TestDataHelper.Get("transfer", "amount"));

            Assert.That(transferFundsPage.IsTransferSuccessful(), Is.True,
                "Chuyển tiền không thành công.");
        }

        [Test]
        [Category("GUI")]
        [Description("TC_GUI_04: Trang Transfer Funds hiển thị đúng các element")]
        public void TC_GUI_04_TransferFundsPage_ElementsDisplayed()
        {
            Assert.That(transferFundsPage.IsOnPage(), Is.True,
                "Header 'Transfer Funds' không hiển thị.");
        }
    }
}
