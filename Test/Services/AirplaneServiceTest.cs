using BusinessLogic.Enums;
using BusinessLogic.Exceptions;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Interfaces;
using DataAccess.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Services
{
    public class AirplaneServiceTest
    {
        [Fact]
        public void AirplaneService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IAirplaneRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Airplane.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirplaneService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Airplane).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void AirplaneService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IAirplaneRepository>();
            mock.Setup(repo => repo.Create(new AirplaneEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirplaneService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new Airplane()));

            // Assert
             Assert.Equal("The Airplane have not empty or null name.", ex.Result.Message);
        }
    }
}
