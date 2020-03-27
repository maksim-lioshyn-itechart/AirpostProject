using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Mappers.CommonMapper;

namespace BusinessLogic.Services
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
            Validation(entity);
            var schemas = await AirplaneSchema.GetBy(entity.Name);
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
                Validation(entity);
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

        private void Validation(AirplaneSchema entity)
        {
            var validator = new Validator<AirplaneSchema>();
            validator.IsValidName(entity.Name);
        }
    }
}
