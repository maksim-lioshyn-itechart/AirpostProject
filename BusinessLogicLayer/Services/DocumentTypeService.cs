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
            var types = await UnitOfWork.DocumentType.GetAll();
            if (types.FirstOrDefault(type => type.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.DocumentType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(DocumentTypeBm entity)
        {
            var type = await UnitOfWork.DocumentType.GetById(entity.Id);
            if (type != null)
            {
                await UnitOfWork.DocumentType.Update(entity.ToDal());
            }
        }

        public async Task Delete(DocumentTypeBm entity)
        {
            var type = await UnitOfWork.DocumentType.GetById(entity.Id);
            if (type != null)
            {
                await UnitOfWork.DocumentType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<DocumentTypeBm>> GetAll() =>
            (await UnitOfWork.DocumentType.GetAll())
            .Select(type => type.ToBm());

        public async Task<DocumentTypeBm> GetById(Guid id) =>
            (await UnitOfWork.DocumentType.GetById(id)).ToBm();
    }
}
