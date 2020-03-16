using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Enums;
using BusinessLogic.Exceptions;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Interfaces;
using DataAccess.Models;
using Moq;
using Xunit;

namespace Test.Services
{
    public class UserServiceTest
    {
        [Fact]
        public void UserService_CheckInsert_Created()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.Create(StubsObjects.User.ToEntity()))
                .Returns(() => Task.CompletedTask);
            var mockPasswordRepo = new Mock<IUserPasswordRepository>();

            var service = new UserService(mockUserRepo.Object, mockPasswordRepo.Object);

            // Act
            var result = service.Create(StubsObjects.User).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void UserService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.Create(new UserEntity()))
                .Returns(() => Task.CompletedTask);
            var mockPasswordRepo = new Mock<IUserPasswordRepository>();

            var service = new UserService(mockUserRepo.Object, mockPasswordRepo.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new User()));

            // Assert
            Assert.Equal("The User have not empty or null name.", ex.Result.Message);
        }

        [Fact]
        public void UserService_CheckInsert_ThrowEmailException()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.Create(new UserEntity()))
                .Returns(() => Task.CompletedTask);
            var mockPasswordRepo = new Mock<IUserPasswordRepository>();

            var service = new UserService(mockUserRepo.Object, mockPasswordRepo.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<IdentityException>(() => service.Create(new User() { FirstName = "Test" }));

            // Assert
            Assert.Equal("Check the correctness of what you entered email.", ex.Result.Message);
        }

        [Fact]
        public void UserService_CheckInsert_ThrowPhoneException()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.Create(new UserEntity()))
                .Returns(() => Task.CompletedTask);
            var mockPasswordRepo = new Mock<IUserPasswordRepository>();

            var service = new UserService(mockUserRepo.Object, mockPasswordRepo.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<IdentityException>(() => service.Create(new User() { FirstName = "Test", Email = "test@test.ru" }));

            // Assert
            Assert.Equal("Check the correctness of what you entered phone.", ex.Result.Message);
        }
    }
}
