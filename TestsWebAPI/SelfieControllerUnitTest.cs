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
            var controller = new SelfiesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.GetEnumerator().MoveNext());
        }
        #endregion
    }
}