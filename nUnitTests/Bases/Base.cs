using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace nUnitTests.Bases
{
    public class Base
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            // options.AddArgument("--headless");
            //options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Url = "https://www.saucedemo.com/";
            Console.WriteLine($"{driver.Manage().Window.Size.Width}x{driver.Manage().Window.Size.Height}");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}