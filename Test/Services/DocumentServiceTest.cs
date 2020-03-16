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
    public class DocumentServiceTest
    {
        [Fact]
        public void DocumentService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IDocumentRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.Document.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new DocumentService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.Document).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void DocumentService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IDocumentRepository>();
            mock.Setup(repo => repo.Create(new DocumentEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new DocumentService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new Document()));

            // Assert
            Assert.Equal("The Document have not empty or null name.", ex.Result.Message);
        }
    }
}
