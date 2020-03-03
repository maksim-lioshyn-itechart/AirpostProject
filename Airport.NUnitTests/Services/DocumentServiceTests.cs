using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Tests;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class DocumentServiceTests
    {
        private readonly IDocumentService _testEntityService;
        private readonly Document _entityBm = StubsObjects.Document;

        public DocumentServiceTests()
        {
            _testEntityService = new DocumentService(TestHelper.Document);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForDocumentService();

            Assert.IsTrue(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.AlreadyExists);
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
            var Document = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(Document.Name, test.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForDocumentService();
        }
    }
}