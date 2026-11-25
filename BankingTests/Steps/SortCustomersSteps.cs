using BankingTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace BankingTests.Steps
{
    [Binding]
    public class SortCustomersSteps
    {
        private readonly LoginPage _loginPage;
        private readonly ManagerPage _managerPage;
        private readonly CustomersPage _customersPage;

        public SortCustomersSteps(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
            _managerPage = new ManagerPage(driver);
            _customersPage = new CustomersPage(driver);
        }

        [Given(@"^I open the XYZ Bank login page$")]
        public void GivenIOpenTheLoginPage() => _loginPage.Open();

        [When(@"^I click the ""Bank Manager Login"" button$")]
        public void WhenIClickBankManagerLogin() => _loginPage.ClickBankManagerLogin();

        [When(@"^I open the ""Customers"" tab$")]
        public void WhenIOpenCustomers() => _managerPage.OpenCustomers();

        [When(@"^I click the ""First Name"" column header (\d+) time\(s\)$")]
        public void WhenIClickFirstNameHeader(int times)
            => _customersPage.ClickFirstNameHeader(times);

        [Then(@"^the customers should be sorted by First Name in (ascending|descending) order$")]
        public void ThenSortedByFirstName(string direction)
        {
            var actual = _customersPage.GetFirstNames();

            var expected = direction == "ascending"
                ? actual.OrderBy(n => n, StringComparer.OrdinalIgnoreCase).ToList()
                : actual.OrderByDescending(n => n, StringComparer.OrdinalIgnoreCase).ToList();

            CollectionAssert.AreEqual(expected, actual,
                $"Customers are not sorted by First Name in {direction} order. " +
                $"Actual: {string.Join(", ", actual)}");
        }
    }
}
