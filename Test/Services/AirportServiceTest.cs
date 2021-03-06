﻿using System;
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
    public class AirportServiceTest
    {
        [Fact]
        public void AirportService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IAirportRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Airport.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirportService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Airport).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void AirportService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IAirportRepository>();
            mock.Setup(repo => repo.Create(new AirportEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new AirportService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new Airport()));

            // Assert
             Assert.Equal("The Airport have not empty or null name.", ex.Result.Message);
        }
    }
}
