using System;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class AirplaneRepositoryTests
    {
        private readonly IAirplaneRepository _repository;
        public AirplaneRepositoryTests()
        {
            _repository = new AirplaneRepository(new ConnectionFactory());
        }
      
        [Test()]
        public void CreateTest()
        {
            _repository.Create(new Models.Airplane()
            {
            AirlineId = Guid.Parse("F5FC60C2-1C9A-48B5-B033-5885837C601F"),
            AirplaneSchemaId = Guid.Parse("C78A05CF-B1C6-457E-94DB-D67EB9C049FA"),
            AirplaneSubTypeId = Guid.Parse("579B1D50-0902-4375-BD77-1B834359F325"),
            AirplaneTypeId = Guid.Parse("48808963-2F3D-4808-BBA9-F1CF0A0F52E6"),
            CarryingCapacity = 100,
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
            }).Wait();

            
        }
    }
}