using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace DataAccessLayer.Tests.Services
{
    [TestFixture()]
    public class TicketServiceTests
    {
        private readonly ITicketService _testEntityService;
        private readonly TicketBm _entityBm = StubsObjects.TicketBm;

        public TicketServiceTests()
        {
            _testEntityService = new TicketService(TestHelper.UnitOfWork);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForTicketService();

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
            var test = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.TicketNumber, test.TicketNumber);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.TicketNumber = "55555";
            _testEntityService.Update(test).Wait();
            var Ticket = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(Ticket.TicketNumber, test.TicketNumber);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForTicketService();
        }
    }
}