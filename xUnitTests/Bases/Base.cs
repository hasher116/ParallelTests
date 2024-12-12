using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace xUnitTests.Bases
{
    public class Base : IDisposable
    {
        protected IWebDriver driver;

        public Base()
        {
            var options = new ChromeOptions();
            // options.AddArgument("--headless");
            //options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Url = "https://www.saucedemo.com/";
            Console.WriteLine($"{driver.Manage().Window.Size.Width}x{driver.Manage().Window.Size.Height}");
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}