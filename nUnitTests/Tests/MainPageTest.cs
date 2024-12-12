using FluentAssertions;
using nUnitTests.Bases;
using nUnitTests.Pages;

namespace DemoLiteCart.nUnitTests.Tests
{
    [TestFixture]
    public class MainPageTest : Base
    {
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]

        public void ShouldBeShownTrueForNewURL_WhenAddLoginAndPassword(string login, string password)
        {
            var expectedURL = "https://www.saucedemo.com/inventory.html";

            var test = new MainPage(driver);
            test.AddLoginAndPassword(login, password)
                .CheckLogin();
            var currentURL = driver.Url;

            currentURL.Should().Be(expectedURL);
        }

        [TestCase("vasya", "123")]
        [TestCase("andrew", "qwerty")]
        [TestCase("asdas", "gsfgfsd")]
        public void ShouldBeShownTrue_WhenAddWrongLoginAndPassword(string login, string password)
        {
            var expectedError = "Epic sadface: Username and password do not match any user in this service";

            var test = new MainPage(driver);
            var currentError = test.AddLoginAndPassword(login, password)
                .CheckLogin()
                .CheckError();

            currentError.Should().Be(expectedError);
        }

        [TestCase("locked_out_user", "secret_sauce")]
        public void ShouldBeShownTrue_WhenAddBlockedLoginAndPassword(string login, string password)
        {
            var expectedError = "Epic sadface: Sorry, this user has been locked out.";

            var test = new MainPage(driver);
            var currentError = test.AddLoginAndPassword(login, password)
                .CheckLogin()
                .CheckError();

            currentError.Should().Be(expectedError);
        }

        [TestCase("performance_glitch_user", "secret_sauce")]
        public void ShouldBeShownFalse_WhenAddGlitchLoginAndPassword(string login, string password)
        {
            var expectedURL = "https://www.saucedemo.com/inventory.html";

            var test = new MainPage(driver);
            test.AddLoginAndPassword(login, password)
                .CheckLogin();

            var currentURL = driver.Url;

            currentURL.Should().Be(expectedURL);
        }
    }
}
