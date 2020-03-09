﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneTypeRepository : IBaseRepository<AirplaneTypeEntity>
    {
        Task<AirplaneTypeEntity> GetBy(string name);
    }
}