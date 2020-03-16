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
    public class FlightServiceTest
    {
        [Fact]
        public void FlightService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IFlightRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Flight.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new FlightService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Flight).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void FlightService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IFlightRepository>();
            mock.Setup(repo => repo.Create(new FlightEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new FlightService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<TimeException>(() => service.Create(new Flight()
            {
                ArrivalTimeUtc = DateTime.Now,
                DepartureTimeUtc = DateTime.Now.AddHours(1)
            }));

            // Assert
             Assert.Equal("Check the correctness of what you entered date interval.", ex.Result.Message);
        }
    }
}
