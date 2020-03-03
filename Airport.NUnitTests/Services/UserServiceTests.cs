using System;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Tests;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class UserServiceTests
    {
        private readonly IUserService _testEntityService;

        private readonly User _entityBm = StubsObjects.User;

        public UserServiceTests()
        {
            _testEntityService = new UserService(TestHelper.User, TestHelper.UserPassword);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForUserService();
            Assert.IsTrue(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
        }

        [Test()]
        [Order(1)]
        public void ValidateTest()
        {
            Assert.IsTrue(_testEntityService.ValidatePassword(_entityBm.Id, _entityBm.Password).Result);
            Assert.IsFalse(_testEntityService.ValidatePassword(_entityBm.Id, Guid.NewGuid().ToString()).Result);
        }

        [Test()]
        [Order(1)]
        public void GetAllTest()
        {
            Assert.GreaterOrEqual(_testEntityService.GetAll().Result.Count(), 1);
        }

        [Test()]
        [Order(1)]
        public void GetByIdTest()
        {
            var result = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.LastName, result.LastName);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.LastName = "Test";
            _testEntityService.Update(test).Wait();
            var result = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(result.LastName, test.LastName);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForUserService();

        }
    }
}