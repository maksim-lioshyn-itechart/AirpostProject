using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using NUnit.Framework;
using System.Linq;

namespace DataAccessLayer.Tests.Services
{
    [TestFixture()]
    public class AirplaneTypeServiceTests
    {
        private readonly IAirplaneTypeService _testEntityService;

        private readonly AirplaneTypeBm _entityBm = StubsObjects.AirplaneTypeBm;

        public AirplaneTypeServiceTests()
        {
            _testEntityService = new AirplaneTypeService(TestHelper.UnitOfWork);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            Assert.IsTrue(_testEntityService.Create(_entityBm).Result);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result);
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
            var airline = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.Name, airline.Name);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.Name = "Test";
            _testEntityService.Update(test).Wait();
            var airline = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(airline.Name, test.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
        }
    }
}