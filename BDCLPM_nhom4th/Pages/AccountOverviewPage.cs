using OpenQA.Selenium;

namespace ParaBankTests.Pages
{
    public class AccountOverviewPage : BasePage
    {
        private By accountsOverviewHeader = By.XPath("//h1[contains(text(),'Accounts Overview')]");
        private By logoutLink = By.LinkText("Log Out");
        private By transferFundsLink = By.LinkText("Transfer Funds");
        private By billPayLink = By.LinkText("Bill Pay");
        private By openAccountLink = By.LinkText("Open New Account");
        private By findTransactionsLink = By.LinkText("Find Transactions");

        public AccountOverviewPage(IWebDriver driver) : base(driver) { }

        public bool IsAtAccountOverview() => IsDisplayed(accountsOverviewHeader);
        public bool IsLogoutVisible() => IsDisplayed(logoutLink);

        public void Logout() => Click(logoutLink);
        public void GoToTransferFunds() => Click(transferFundsLink);
        public void GoToBillPay() => Click(billPayLink);
        public void GoToOpenAccount() => Click(openAccountLink);
        public void GoToFindTransactions() => Click(findTransactionsLink);

        public bool IsTransferFundsLinkDisplayed() => IsDisplayed(transferFundsLink);
        public bool IsBillPayLinkDisplayed() => IsDisplayed(billPayLink);
        public bool IsOpenAccountLinkDisplayed() => IsDisplayed(openAccountLink);
    }
}
