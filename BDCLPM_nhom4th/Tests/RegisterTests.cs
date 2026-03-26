using NUnit.Framework;
using ParaBankTests.Pages;
using ParaBankTests.Utilities;

namespace ParaBankTests.Tests
{
    [TestFixture]
    [Category("Functional")]
    public class RegisterTests : BaseTest
    {
        private RegisterPage registerPage = null!;

        // Dữ liệu dùng chung theo test case
        private const string FirstName  = "Nguyen";
        private const string LastName   = "Van A";
        private const string Address    = "123 Le Loi, HCM";
        private const string City       = "Ho Chi Minh";
        private const string State      = "HCM";
        private const string ZipCode    = "700000";
        private const string Phone      = "0901234567";
        private const string SSN        = "123456789";
        private const string Username   = "user_ts01_001";
        private const string Password   = "Test@123";

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
            registerPage = new RegisterPage(driver!);
            registerPage.Open();
        }

        /// <summary>
        /// TC_TS_01_01: Đăng ký tài khoản mới với thông tin hợp lệ
        /// Expected: Tài khoản được tạo thành công, hiển thị thông báo chào mừng
        /// </summary>
        [Test]
        [Description("TC_TS_01_01: Kiểm tra đăng ký tài khoản mới với thông tin hợp lệ")]
        public void TC_TS_01_01_RegisterSuccessfully_WithValidData()
        {
            string uniqueUsername = registerPage.GenerateUniqueUsername();

            registerPage.Register(
                FirstName, LastName, Address, City,
                State, ZipCode, Phone, SSN,
                uniqueUsername, Password, Password
            );

            Assert.Multiple(() =>
            {
                Assert.That(registerPage.IsWelcomeDisplayed(), Is.True,
                    "Không hiển thị tiêu đề Welcome sau khi đăng ký.");
                Assert.That(registerPage.GetSuccessMessage(),
                    Does.Contain("Your account was created successfully"),
                    "Không hiển thị thông báo tạo tài khoản thành công.");
            });
        }

        /// <summary>
        /// TC_TS_02_01: Bỏ trống tất cả trường bắt buộc
        /// Expected: Hiển thị thông báo lỗi yêu cầu nhập dữ liệu
        /// </summary>
        [Test]
        [Description("TC_TS_02_01: Kiểm tra bỏ trống tất cả trường bắt buộc khi đăng ký")]
        public void TC_TS_02_01_Register_FailsWhenAllFieldsEmpty()
        {
            // Không nhập gì, nhấn Register luôn
            registerPage.ClickRegister();

            Assert.That(registerPage.IsAnyErrorDisplayed(), Is.True,
                "Không hiển thị thông báo lỗi khi bỏ trống tất cả trường.");
        }

        /// <summary>
        /// TC_TS_02_02: Bỏ trống trường First Name
        /// Expected: Hiển thị thông báo lỗi cho First Name
        /// </summary>
        [Test]
        [Description("TC_TS_02_02: Kiểm tra bỏ trống trường First Name")]
        public void TC_TS_02_02_Register_FailsWhenFirstNameEmpty()
        {
            registerPage.Register(
                "",         // First Name bỏ trống
                LastName, Address, City,
                State, ZipCode, Phone, SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsFirstNameErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống First Name.");
        }

        /// <summary>
        /// TC_TS_02_03: Bỏ trống trường Last Name
        /// Expected: Hiển thị thông báo lỗi cho Last Name
        /// </summary>
        [Test]
        [Description("TC_TS_02_03: Kiểm tra bỏ trống trường Last Name")]
        public void TC_TS_02_03_Register_FailsWhenLastNameEmpty()
        {
            registerPage.Register(
                FirstName,
                "",         // Last Name bỏ trống
                Address, City,
                State, ZipCode, Phone, SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsLastNameErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống Last Name.");
        }

        /// <summary>
        /// TC_TS_02_04: Bỏ trống trường Address
        /// Expected: Hiển thị thông báo lỗi cho Address
        /// </summary>
        [Test]
        [Description("TC_TS_02_04: Kiểm tra bỏ trống trường Address")]
        public void TC_TS_02_04_Register_FailsWhenAddressEmpty()
        {
            registerPage.Register(
                FirstName, LastName,
                "",         // Address bỏ trống
                City,
                State, ZipCode, Phone, SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsAddressErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống Address.");
        }

        /// <summary>
        /// TC_TS_02_05: Bỏ trống trường City
        /// Expected: Hiển thị thông báo lỗi cho City
        /// </summary>
        [Test]
        [Description("TC_TS_02_05: Kiểm tra bỏ trống trường City")]
        public void TC_TS_02_05_Register_FailsWhenCityEmpty()
        {
            registerPage.Register(
                FirstName, LastName, Address,
                "",         // City bỏ trống
                State, ZipCode, Phone, SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsCityErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống City.");
        }

        /// <summary>
        /// TC_TS_02_06: Bỏ trống trường State
        /// Expected: Hiển thị thông báo lỗi cho State
        /// </summary>
        [Test]
        [Description("TC_TS_02_06: Kiểm tra bỏ trống trường State")]
        public void TC_TS_02_06_Register_FailsWhenStateEmpty()
        {
            registerPage.Register(
                FirstName, LastName, Address, City,
                "",         // State bỏ trống
                ZipCode, Phone, SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsStateErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống State.");
        }

        /// <summary>
        /// TC_TS_02_07: Bỏ trống trường Zip Code
        /// Expected: Hiển thị thông báo lỗi cho Zip Code
        /// </summary>
        [Test]
        [Description("TC_TS_02_07: Kiểm tra bỏ trống trường Zip Code")]
        public void TC_TS_02_07_Register_FailsWhenZipCodeEmpty()
        {
            registerPage.Register(
                FirstName, LastName, Address, City,
                State,
                "",         // Zip Code bỏ trống
                Phone, SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsZipCodeErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống Zip Code.");
        }

        /// <summary>
        /// TC_TS_02_08: Bỏ trống trường SSN
        /// Expected: Hiển thị thông báo lỗi cho SSN
        /// </summary>
        [Test]
        [Description("TC_TS_02_08: Kiểm tra bỏ trống trường SSN")]
        public void TC_TS_02_08_Register_FailsWhenSSNEmpty()
        {
            registerPage.Register(
                FirstName, LastName, Address, City,
                State, ZipCode, Phone,
                "",         // SSN bỏ trống
                Username, Password, Password
            );

            Assert.That(registerPage.IsSsnErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống SSN.");
        }

        /// <summary>
        /// TC_TS_02_09: Bỏ trống trường Phone
        /// Expected: Hiển thị thông báo lỗi cho Phone
        /// </summary>
        [Test]
        [Description("TC_TS_02_09: Kiểm tra bỏ trống trường Phone")]
        public void TC_TS_02_09_Register_FailsWhenPhoneEmpty()
        {
            registerPage.Register(
                FirstName, LastName, Address, City,
                State, ZipCode,
                "",         // Phone bỏ trống
                SSN,
                Username, Password, Password
            );

            Assert.That(registerPage.IsPhoneErrorDisplayed(), Is.True,
                "Không hiển thị lỗi khi bỏ trống Phone.");
        }
    }
}
