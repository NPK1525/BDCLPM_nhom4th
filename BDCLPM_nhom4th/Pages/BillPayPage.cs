using OpenQA.Selenium;

namespace ParaBankTests.Pages
{
    public class BillPayPage : BasePage
    {
        private By payeeNameInput = By.Name("payee.name");
        private By addressInput = By.Name("payee.address.street");
        private By cityInput = By.Name("payee.address.city");
        private By stateInput = By.Name("payee.address.state");
        private By zipCodeInput = By.Name("payee.address.zipCode");
        private By phoneInput = By.Name("payee.phoneNumber");
        private By accountNumberInput = By.Name("payee.accountNumber");
        private By verifyAccountInput = By.Name("verifyAccount");
        private By amountInput = By.Name("amount");
        private By sendPaymentButton = By.XPath("//input[@value='Send Payment']");
        private By successMessage = By.XPath("//h1[contains(text(),'Bill Payment Complete')]");
        private By pageHeader = By.XPath("//h1[contains(text(),'Bill Pay')]");

        public BillPayPage(IWebDriver driver) : base(driver) { }

        public bool IsOnPage() => IsDisplayed(pageHeader);

        public void FillPayeeInfo(string name, string address, string city, string state,
            string zip, string phone, string accountNumber, string amount)
        {
            Type(payeeNameInput, name);
            Type(addressInput, address);
            Type(cityInput, city);
            Type(stateInput, state);
            Type(zipCodeInput, zip);
            Type(phoneInput, phone);
            Type(accountNumberInput, accountNumber);
            Type(verifyAccountInput, accountNumber);
            Type(amountInput, amount);
        }

        public void ClickSendPayment() => Click(sendPaymentButton);

        public bool IsPaymentSuccessful() => IsDisplayed(successMessage);
    }
}
