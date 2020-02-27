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
        private IAirplaneSchemaRepository AirplaneSchema { get; }

        public AirplaneSchemaService(IAirplaneSchemaRepository airplaneSchema)
        {
            AirplaneSchema = airplaneSchema;
        }

        public async Task<bool> Create(AirplaneSchema entity)
        {
            var schemas = await AirplaneSchema.GetAll();
            if (schemas.FirstOrDefault(schema => schema.Name == entity.Name) != null)
            {
                return false;
            }
            await AirplaneSchema.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(AirplaneSchema entity)
        {
            var schemas = await AirplaneSchema.GetById(entity.Id);
            if (schemas != null)
            {
                await AirplaneSchema.Update(entity.ToEntity());
            }
        }

        public async Task Delete(AirplaneSchema entity)
        {
            var schemas = await AirplaneSchema.GetById(entity.Id);
            if (schemas != null)
            {
                await AirplaneSchema.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneSchema>> GetAll() =>
            (await AirplaneSchema.GetAll())
            .Select(schema => schema.ToModel());

        public async Task<AirplaneSchema> GetById(Guid id) =>
            (await AirplaneSchema.GetById(id)).ToModel();
    }
}
