using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogicLayer.Mappers.CommonMapper;

namespace BusinessLogicLayer.Services
{
    public class AirplaneSchemaService : IAirplaneSchemaService
    {
        private IUnitOfWork UnitOfWork { get; }

        public AirplaneSchemaService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(AirplaneSchemaBm entity)
        {
            var schemas = await UnitOfWork.AirplaneSchema.GetAll();
            if (schemas.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.AirplaneSchema.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirplaneSchemaBm entity)
        {
            var schemas = await UnitOfWork.AirplaneSchema.GetById(entity.Id);
            if (schemas != null)
            {
                await UnitOfWork.AirplaneSchema.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirplaneSchemaBm entity)
        {
            var schemas = await UnitOfWork.AirplaneSchema.GetById(entity.Id);
            if (schemas != null)
            {
                await UnitOfWork.AirplaneSchema.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneSchemaBm>> GetAll() =>
            (await UnitOfWork.AirplaneSchema.GetAll())
            .Select(a => a.ToBm());

        public async Task<AirplaneSchemaBm> GetById(Guid id) =>
            (await UnitOfWork.AirplaneSchema.GetById(id)).ToBm();
    }
}
