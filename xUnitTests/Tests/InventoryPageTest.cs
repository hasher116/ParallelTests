using FluentAssertions;
using xUnitTests.Bases;
using xUnitTests.Pages;

namespace xUnitTests.Tests
{
    public class InventoryPageTest : Base
    {
        [Theory]
        [InlineData("performance_glitch_user", "secret_sauce")]
        public void CheckProduct_WhenUsedGlitchUser(string username, string password)
        {
            string expectedText = "Products";

            var mainPage = new MainPage(driver);
            mainPage.AddLoginAndPassword(username, password)
                .CheckLogin();

            var inventoryPage = new InventoryPage(driver);

            inventoryPage.CheckLocator().Should().BeEquivalentTo(expectedText);
        }
    }
}
