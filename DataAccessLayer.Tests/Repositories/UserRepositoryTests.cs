using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class UserRepositoryTests
    {
        private readonly IBaseRepository<User> _repository;

        readonly User _entity = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = Guid.NewGuid().ToString(),
            Phone = Guid.NewGuid().ToString(),
            Address = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            RoleId = Guid.Parse("026D358E-4DBC-4338-A106-663CA2AF7CC9")
        };

        public UserRepositoryTests()
        {
            _repository = new UserRepository(new Test());
        }

        [Test()]
        [Order(1)]
        public void CreateTest()
        {
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
            test.FirstName = "Test";
            _repository.Update(test).Wait();
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.FirstName, _entity.FirstName);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
        }
    }
}