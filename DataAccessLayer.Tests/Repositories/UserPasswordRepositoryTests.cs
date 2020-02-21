using System;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class UserPasswordRepositoryTests
    {
        private readonly IBaseRepository<UserPassword> _repository;

        readonly UserPassword _entity = new UserPassword()
        {
            Id = Guid.NewGuid(),
            UserId = Guid.Parse("B487A891-4933-467E-8E50-9F02A8DA464D"),
            Salt = Encoding.UTF8.GetBytes("Salt"),
            Hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("Salt"))
        };

        public UserPasswordRepositoryTests()
        {
            _repository = new UserPasswordRepository(new Test());
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
            test.Salt = Encoding.UTF8.GetBytes("TestTestTestTest");
            _repository.Update(test).Wait();
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.Salt, _entity.Salt);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
        }
    }
}