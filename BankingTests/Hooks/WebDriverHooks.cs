using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace BankingTests.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver? _driver;

        public WebDriverHooks(IObjectContainer container) => _container = container;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void TearDown() => _driver?.Quit();
    }
}
