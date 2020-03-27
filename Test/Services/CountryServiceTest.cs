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
    public class CountryServiceTest
    {
        [Fact]
        public void CountryService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<ICountryRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Country.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new CountryService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Country).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void CountryService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<ICountryRepository>();
            mock.Setup(repo => repo.Create(new CountryEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new CountryService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new Country()));

            // Assert
            Assert.Equal("The Country have not empty or null name.", ex.Result.Message);
        }
    }
}
