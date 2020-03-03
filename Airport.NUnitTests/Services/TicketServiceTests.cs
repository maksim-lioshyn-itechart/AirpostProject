﻿using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class TicketServiceTests
    {
        private readonly ITicketService _testEntityService;
        private readonly Ticket _entityBm = StubsObjects.Ticket;

        public TicketServiceTests()
        {
            _testEntityService = new TicketService(TestHelper.Ticket);
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
            Assert.AreEqual(_entityBm.TicketNumber, test.TicketNumber);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.TicketNumber = "55555";
            _testEntityService.Update(test).Wait();
            var ticket = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(ticket.TicketNumber, test.TicketNumber);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteAllEntities(_entityBm);
        }
    }
}