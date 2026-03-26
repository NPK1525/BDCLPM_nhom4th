using OpenQA.Selenium;

namespace ParaBankTests.Pages
{
    public class TransferFundsPage : BasePage
    {
        private By amountInput = By.Id("amount");
        private By fromAccountSelect = By.Id("fromAccountId");
        private By toAccountSelect = By.Id("toAccountId");
        private By transferButton = By.XPath("//input[@value='Transfer']");
        private By successMessage = By.XPath("//h1[contains(text(),'Transfer Complete')]");
        private By pageHeader = By.XPath("//h1[contains(text(),'Transfer Funds')]");

        public TransferFundsPage(IWebDriver driver) : base(driver) { }

        public bool IsOnPage() => IsDisplayed(pageHeader);

        public void Transfer(string amount)
        {
            Type(amountInput, amount);
            Click(transferButton);
        }

        public bool IsTransferSuccessful() => IsDisplayed(successMessage);
        public string GetSuccessMessage() => GetText(successMessage);
    }
}
