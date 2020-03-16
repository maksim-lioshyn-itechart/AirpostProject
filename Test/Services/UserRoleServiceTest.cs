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
    public class UserRoleServiceTest
    {
        [Fact]
        public void UserRoleService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IUserRoleRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.UserRole.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new UserRoleService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.UserRole).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void UserRoleService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IUserRoleRepository>();
            mock.Setup(repo => repo.Create(new UserRoleEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new UserRoleService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new UserRole()));

            // Assert
             Assert.Equal("The UserRole have not empty or null name.", ex.Result.Message);
        }
    }
}
