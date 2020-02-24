using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Models;

namespace DataAccessLayer.Tests
{
    public static class StubsObjects
    {
        public static AirlineBm AirlineBm = new AirlineBm()
        {
            Id = Guid.NewGuid(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Address = Guid.NewGuid().ToString(),
            Phone = "12093",
            Url = Guid.NewGuid().ToString(),
            CountryId = Guid.Parse("28E0F235-64E2-4A82-A0D0-3D62E6E0F4D5")
        };


        public static AirplaneSchemaBm AirplaneSchemaBm = new AirplaneSchemaBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static AirplaneSubTypeBm AirplaneSubTypeBm = new AirplaneSubTypeBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static AirplaneTypeBm AirplaneTypeBm = new AirplaneTypeBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static ClassTypeBm ClassTypeBm = new ClassTypeBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static CountryBm CountryBm = new CountryBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            Code = "Der"
        };

        public static DocumentTypeBm DocumentTypeBm = new DocumentTypeBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static OrderStatusBm OrderStatusBm = new OrderStatusBm()
        {
            Id = Guid.NewGuid(),
            Name = "NewStatus"
        };

        public static UserRoleBm UserRoleBm = new UserRoleBm()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static AirplaneBm AirplaneBm = new AirplaneBm
        {
            Id = Guid.NewGuid(),
            AirlineId = AirlineBm.Id,
            AirplaneSchemaId = AirplaneSchemaBm.Id,
            AirplaneSubTypeId = AirplaneSubTypeBm.Id,
            AirplaneTypeId = AirplaneTypeBm.Id,
            CarryingCapacity = 100,
            Name = "Test"
        };
    }
}
