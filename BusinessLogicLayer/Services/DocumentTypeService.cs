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
    public class DocumentTypeService : IDocumentTypeService
    {
        private IUnitOfWork UnitOfWork { get; }

        public DocumentTypeService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(DocumentTypeBm entity)
        {
            var airplanes = await UnitOfWork.DocumentType.GetAll();
            if (airplanes.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.DocumentType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(DocumentTypeBm entity)
        {
            var airplanes = await UnitOfWork.DocumentType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.DocumentType.Update(entity.ToDal());
            }
        }

        public async Task Delete(DocumentTypeBm entity)
        {
            var airplanes = await UnitOfWork.DocumentType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.DocumentType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<DocumentTypeBm>> GetAll() =>
            (await UnitOfWork.DocumentType.GetAll())
            .Select(a => a.ToBm());

        public async Task<DocumentTypeBm> GetById(Guid id) =>
            (await UnitOfWork.DocumentType.GetById(id)).ToBm();
    }
}
