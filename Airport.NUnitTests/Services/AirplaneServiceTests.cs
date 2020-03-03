using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class AirplaneServiceTests
    {
        private readonly IAirplaneService _testEntityService;
        private readonly Airplane _entityBm = StubsObjects.Airplane;

        public AirplaneServiceTests()
        {
            _testEntityService = new AirplaneService(TestHelper.Airplane);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateAllEntities(_entityBm);
            Assert.IsTrue(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
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
            var test = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.Name, test.Name);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.Name = "Test";
            _testEntityService.Update(test).Wait();
            var airplane = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(airplane.Name, test.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            TestHelper.DeleteAllEntities(_entityBm);
            _testEntityService.Delete(_entityBm).Wait();
            
        }
    }
}