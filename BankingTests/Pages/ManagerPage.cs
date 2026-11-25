using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BankingTests.Pages
{
    public class ManagerPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private By CustomersButton => By.CssSelector("button[ng-click='showCust()']");

        public ManagerPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenCustomers()
        {
            _wait.Until(d => d.FindElement(CustomersButton).Displayed);
            _driver.FindElement(CustomersButton).Click();
        }
    }
}
