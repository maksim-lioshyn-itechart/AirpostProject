using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;
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

        public async Task<StatusCode> Create(AirplaneSchema entity)
        {
            var schemas = (await AirplaneSchema.GetBy(entity.Name)).FirstOrDefault();
            var isExist = schemas != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await AirplaneSchema.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(AirplaneSchema entity)
        {
            var schemas = await AirplaneSchema.GetById(entity.Id);
            if (schemas != null)
            {
                await AirplaneSchema.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(AirplaneSchema entity)
        {
            var schemas = await AirplaneSchema.GetById(entity.Id);
            if (schemas != null)
            {
                await AirplaneSchema.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<AirplaneSchema>> GetAll() =>
            (await AirplaneSchema.GetAll())
            .Select(schema => schema.ToModel());

        public async Task<AirplaneSchema> GetById(Guid id) =>
            (await AirplaneSchema.GetById(id))?.ToModel();
    }
}
