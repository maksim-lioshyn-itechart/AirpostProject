﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<TModel>
    {
        Task<StatusCode> Create(TModel entity);
        Task<StatusCode> Update(TModel entity);
        Task<StatusCode> Delete(TModel entity);

        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(Guid id);
    }
}