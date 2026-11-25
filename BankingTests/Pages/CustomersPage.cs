using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BankingTests.Pages
{
    public class CustomersPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private By FirstNameHeader => By.XPath("//table//a[normalize-space()='First Name']");
        private By FirstNameCells => By.CssSelector("table tbody tr td:nth-child(1)");

        public CustomersPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickFirstNameHeader(int times)
        {
            _wait.Until(d => d.FindElement(FirstNameHeader).Displayed);
            for (int i = 0; i < times; i++)
                _driver.FindElement(FirstNameHeader).Click();
        }

        public List<string> GetFirstNames()
        {
            _wait.Until(d => d.FindElements(FirstNameCells).Count > 0);
            return _driver.FindElements(FirstNameCells)
                          .Select(c => c.Text.Trim())
                          .ToList();
        }
    }
}
