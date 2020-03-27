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
    public class AirlineServiceTest
    {
        [Fact]
        public void AirlineService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IAirlineRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Airline.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirlineService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Airline).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void AirlineService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IAirlineRepository>();
            mock.Setup(repo => repo.Create(new AirlineEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirlineService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new Airline()));

            // Assert
            Assert.Equal("The Airline have not empty or null name.", ex.Result.Message);
        }

        [Fact]
        public void AirlineService_CheckInsert_ThrowEmailException()
        {
            // Arrange
            var mock = new Mock<IAirlineRepository>();
            mock.Setup(repo => repo.Create(new AirlineEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirlineService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<IdentityException>(() => service.Create(new Airline() { Name = "Test"}));

            // Assert
            Assert.Equal("Check the correctness of what you entered email.", ex.Result.Message);
        }

        [Fact]
        public void AirlineService_CheckInsert_ThrowPhoneException()
        {
            // Arrange
            var mock = new Mock<IAirlineRepository>();
            mock.Setup(repo => repo.Create(new AirlineEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirlineService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<IdentityException>(() => service.Create(new Airline() { Name = "Test", Email = "test@test.ru"}));

            // Assert
            Assert.Equal("Check the correctness of what you entered phone.", ex.Result.Message);
        }
    }
}
