using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BankingTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string Url =
            "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";

        private By ManagerLoginButton => By.CssSelector("button[ng-click='manager()']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Open() => _driver.Navigate().GoToUrl(Url);

        public void ClickBankManagerLogin()
        {
            _wait.Until(d => d.FindElement(ManagerLoginButton).Displayed);
            _driver.FindElement(ManagerLoginButton).Click();
        }
    }
}
