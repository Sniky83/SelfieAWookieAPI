using Microsoft.AspNetCore.Mvc;
using SelfieAWookieAPI.Controllers;

namespace TestsWebAPI
{
    public class SelfieControllerUnitTest
    {
        #region Public Methods
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // Arrange
            var controller = new SelfiesController(null);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
        }
        #endregion
    }
}