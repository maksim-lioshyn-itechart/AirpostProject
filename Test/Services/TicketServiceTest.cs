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
    public class TicketServiceTest
    {
        [Fact]
        public void TicketService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<ITicketRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Ticket.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new TicketService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Ticket).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

    }
}
