using System.Web.Mvc;
using Portfolio.Controllers;
using Xunit;

namespace PortfolioTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
