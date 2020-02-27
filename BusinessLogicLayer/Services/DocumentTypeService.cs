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
        private IDocumentTypeRepository DocumentType { get; }

        public DocumentTypeService(IDocumentTypeRepository documentType)
        {
            DocumentType = documentType;
        }

        public async Task<bool> Create(DocumentType entity)
        {
            var types = (await DocumentType.GetAll())
                .FirstOrDefault(type => type.Name == entity.Name);
            var isExist = types != null;

            if (isExist)
            {
                return false;
            }

            await DocumentType.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(DocumentType entity)
        {
            var type = await DocumentType.GetById(entity.Id);
            if (type != null)
            {
                await DocumentType.Update(entity.ToEntity());
            }
        }

        public async Task Delete(DocumentType entity)
        {
            var type = await DocumentType.GetById(entity.Id);
            if (type != null)
            {
                await DocumentType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<DocumentType>> GetAll() =>
            (await DocumentType.GetAll())
            .Select(type => type.ToModel());

        public async Task<DocumentType> GetById(Guid id) =>
            (await DocumentType.GetById(id))?.ToModel();
    }
}
