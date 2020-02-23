﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<TBM>
    {
        Task<bool> Create(TBM entity);
        Task Update(TBM entity);
        Task Delete(TBM entity);

        Task<IEnumerable<Airline>> GetAll();
        Task<Airline> GetById(Guid id);
    }
}