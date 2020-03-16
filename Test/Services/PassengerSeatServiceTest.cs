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
    public class PassengerSeatServiceTest
    {
        [Fact]
        public void PassengerSeatService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IPassengerSeatRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.PassengerSeat.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new PassengerSeatService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.PassengerSeat).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }
    }
}
