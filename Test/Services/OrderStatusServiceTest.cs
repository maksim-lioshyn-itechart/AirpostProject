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
    public class OrderStatusServiceTest
    {
        [Fact]
        public void OrderStatusService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IOrderStatusRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.OrderStatus.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new OrderStatusService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.OrderStatus).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void OrderStatusService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IOrderStatusRepository>();
            mock.Setup(repo => repo.Create(new OrderStatusEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new OrderStatusService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new OrderStatus()));

            // Assert
             Assert.Equal("The OrderStatus have not empty or null name.", ex.Result.Message);
        }
    }
}
