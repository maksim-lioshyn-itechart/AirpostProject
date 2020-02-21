using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class DocumentRepositoryTests
    {
        private readonly IBaseRepository<Document> _repository;

        static readonly DocumentType _entityDocumentType = new DocumentType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            
        };

        readonly Document _entity = new Document()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            DocumentTypeId = _entityDocumentType.Id,
            Number = Guid.NewGuid().ToString()
        };

        public DocumentRepositoryTests()
        {
            _repository = new DocumentRepository(new Test());
        }

        [Test()]
        [Order(1)]
        public void CreateTest()
        {
            new DocumentTypeRepository(new Test()).Create(_entityDocumentType).Wait();
            _repository.Create(_entity).Wait();
        }

        [Test()]
        [Order(2)]
        public void GetByIdTest()
        {
            var test = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(test.Id, _entity.Id);
        }

        [Test()]
        [Order(3)]
        public void GetAllTest()
        {
            var tests = _repository.GetAll().Result;
            Assert.GreaterOrEqual(tests.AsList().Count, 1);
        }

        [Test()]
        [Order(4)]
        public void UpdateTest()
        {
            var test = _entity;
            test.Name = "Test";
            _repository.Update(test).Wait();
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.Name, _entity.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
            new DocumentTypeRepository(new Test()).Delete(_entityDocumentType.Id).Wait();
        }
    }
}