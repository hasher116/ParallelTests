using FluentAssertions;
using xUnitTests.Bases;
using xUnitTests.Pages;

namespace xUnitTests.Tests
{
    public class MainPageTest : Base
    {
        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]

        public void ShouldBeShownTrueForNewURL_WhenAddLoginAndPassword(string login, string password)
        {
            var expectedURL = "https://www.saucedemo.com/inventory.html";

            var test = new MainPage(driver);
            test.AddLoginAndPassword(login, password)
                .CheckLogin();
            var currentURL = driver.Url;

            currentURL.Should().Be(expectedURL);
        }

        [Theory]
        [InlineData("vasya", "123")]
        [InlineData("andrew", "qwerty")]
        [InlineData("asdas", "gsfgfsd")]
        public void ShouldBeShownTrue_WhenAddWrongLoginAndPassword(string login, string password)
        {
            var expectedError = "Epic sadface: Username and password do not match any user in this service";

            var test = new MainPage(driver);
            var currentError = test.AddLoginAndPassword(login, password)
                .CheckLogin()
                .CheckError();

            currentError.Should().Be(expectedError);
        }

        [Theory]
        [InlineData("locked_out_user", "secret_sauce")]
        public void ShouldBeShownTrue_WhenAddBlockedLoginAndPassword(string login, string password)
        {
            var expectedError = "Epic sadface: Sorry, this user has been locked out.";

            var test = new MainPage(driver);
            var currentError = test.AddLoginAndPassword(login, password)
                .CheckLogin()
                .CheckError();

            currentError.Should().Be(expectedError);
        }

        [Theory]
        [InlineData("performance_glitch_user", "secret_sauce")]
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
