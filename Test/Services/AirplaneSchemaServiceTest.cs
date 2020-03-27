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
    public class AirplaneSchemaServiceTest
    {
        [Fact]
        public void AirplaneSchemaService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IAirplaneSchemaRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.AirplaneSchema.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirplaneSchemaService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.AirplaneSchema).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void AirplaneSchemaService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IAirplaneSchemaRepository>();
            mock.Setup(repo => repo.Create(new AirplaneSchemaEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirplaneSchemaService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new AirplaneSchema()));

            // Assert
            Assert.Equal("The AirplaneSchema have not empty or null name.", ex.Result.Message);
        }
    }
}
