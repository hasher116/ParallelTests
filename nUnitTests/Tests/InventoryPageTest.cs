using FluentAssertions;
using nUnitTests.Bases;
using nUnitTests.Pages;

namespace DemoLiteCart.nUnitTests.Tests
{
    [TestFixture]
    public class InventoryPageTest : Base
    {
        [TestCase("performance_glitch_user", "secret_sauce")]
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
