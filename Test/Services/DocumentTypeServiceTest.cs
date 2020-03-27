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
    public class DocumentTypeServiceTest
    {
        [Fact]
        public void DocumentTypeService_CheckInsert_Created()
        {
            // Arrange
            var mock = new Mock<IDocumentTypeRepository>();
            mock.Setup(repo => repo.Create(StubsObjects.DocumentType.ToEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new DocumentTypeService(mock.Object);

            // Act
            var result = service.Create(StubsObjects.DocumentType).Result;

            // Assert
            Assert.Equal(StatusCode.Created, result);
        }

        [Fact]
        public void DocumentTypeService_CheckInsert_ThrowNameException()
        {
            // Arrange
            var mock = new Mock<IDocumentTypeRepository>();
            mock.Setup(repo => repo.Create(new DocumentTypeEntity()))
                .Returns(() => Task.CompletedTask);

            var service = new DocumentTypeService(mock.Object);

            // Act
            var ex = Assert.ThrowsAnyAsync<NameException>(() => service.Create(new DocumentType()));

            // Assert
             Assert.Equal("The DocumentType have not empty or null name.", ex.Result.Message);
        }
    }
}
