﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAirlineRepository : IBaseRepository<AirlineEntity>
    {
        Task<IEnumerable<AirlineEntity>> GetBy(string email = null, Guid? countryId = null);
    }
}