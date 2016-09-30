using System.Web.Mvc;
using Portfolio.Controllers;
using Portfolio.Models;
using Xunit;

namespace PortfolioTests
{
    public class HistoryTests
    {
        [Fact]
        public void HistoryReceivesViewModel()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.History() as ViewResult;
            var model = result?.Model as HistoryViewModel;

            // Assert
            Assert.NotNull(model);
        }
    }
}
