using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class OrderStatusRepositoryTests
    {
        private readonly IBaseRepository<OrderStatus> _repository;

        readonly OrderStatus _entity = new OrderStatus()
        {
            Id = Guid.NewGuid(),
            Name = "TestStatus"
            
        };

        public OrderStatusRepositoryTests()
        {
            _repository = new OrderStatusRepository(new Test());
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
        }
    }
}