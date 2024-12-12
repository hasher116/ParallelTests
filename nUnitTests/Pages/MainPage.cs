using OpenQA.Selenium;

namespace nUnitTests.Pages
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        private readonly By locatorLoginField = By.Id("user-name");
        private readonly By locatorPasswordField = By.Id("password");
        private readonly By locatorButtonLogin = By.Id("login-button");
        private readonly By locatorErrorMessage = By.XPath("//div[@class = 'error-message-container error']");

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainPage AddLoginAndPassword(string login, string password)
        {
            driver.FindElement(locatorLoginField).SendKeys(login);
            driver.FindElement(locatorPasswordField).SendKeys(password);
            return this;
        }

        public MainPage CheckLogin()
        {
            driver.FindElement(locatorButtonLogin).Click();
            return this;
        }

        public string CheckError()
        {
            return driver.FindElement(locatorErrorMessage).Text;
        }
    }
}
