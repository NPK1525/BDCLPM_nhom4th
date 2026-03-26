using OpenQA.Selenium;

namespace ParaBankTests.Pages
{
    public class FindTransactionsPage : BasePage
    {
        private By accountSelect = By.Id("accountId");
        private By transactionIdInput = By.Id("transactionId");
        private By findByIdButton = By.Id("findById");
        private By amountInput = By.Id("amount");
        private By findByAmountButton = By.Id("findByAmount");
        private By resultsTable = By.Id("transactionTable");
        private By pageHeader = By.XPath("//h1[contains(text(),'Find Transactions')]");
        private By noResultsMessage = By.XPath("//*[contains(text(),'No transactions found')]");

        public FindTransactionsPage(IWebDriver driver) : base(driver) { }

        public bool IsOnPage() => IsDisplayed(pageHeader);

        public void FindByAmount(string amount)
        {
            Type(amountInput, amount);
            Click(findByAmountButton);
        }

        public bool IsResultsTableDisplayed() => IsDisplayed(resultsTable);
        public bool IsNoResultsMessageDisplayed() => IsDisplayed(noResultsMessage);
    }
}
