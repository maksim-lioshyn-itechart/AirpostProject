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
    public class ClassTypeServiceTest
    {
        [Fact]
        public void ClassTypeService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IClassTypeRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.ClassType.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new ClassTypeService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.ClassType).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void ClassTypeService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IClassTypeRepository>();
            mock.Setup(repo => repo.Create(new ClassTypeEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new ClassTypeService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new ClassType()));

            // Assert
             Assert.Equal("The ClassType have not empty or null name.", ex.Result.Message);
        }
    }
}
