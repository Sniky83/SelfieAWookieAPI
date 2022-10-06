using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookieAPI.Application.DTOs;
using SelfieAWookieAPI.Controllers;
using SelfiesAWookies.Core.Framework;

namespace TestsWebAPI
{
    public class SelfieControllerUnitTest
    {
        #region Public Methods
        [Fact]
        public void ShouldAddOneSelfie()
        {
            // Arrange
            SelfieDto selfie = new SelfieDto();
            var repositoryMock = new Mock<ISelfieRepository>();
            var unit = new Mock<IUnitOfWork>().Object;

            repositoryMock.Setup(item => item.UnitOfWork).Returns(new Mock<IUnitOfWork>().Object);
            repositoryMock.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });

            // Act
            var controller = new SelfiesController(repositoryMock.Object);
            var result = controller.AddOne(selfie);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var addedSelfie = (result as OkObjectResult).Value as SelfieDto;
            Assert.NotNull(addedSelfie);
            Assert.True(addedSelfie.Id > 0);
        }

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // Arrange
            var expectedList = new List<Selfie>()
            {
                new Selfie() { Wookie = new Wookie() },
                new Selfie() { Wookie = new Wookie() }
            };

            var repositoryMock = new Mock<ISelfieRepository>();

            repositoryMock.Setup(item => item.GetAll()).Returns(expectedList);

            var controller = new SelfiesController(repositoryMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.IsType<List<SelfieResumeDto>>(okResult.Value);

            List<SelfieResumeDto> list = okResult.Value as List<SelfieResumeDto>;
            Assert.True(list.Count == expectedList.Count);
        }
        #endregion
    }
}