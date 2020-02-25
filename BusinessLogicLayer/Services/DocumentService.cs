using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DocumentService : IDocumentService
    {
        private IUnitOfWork UnitOfWork { get; }

        public DocumentService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(DocumentBm entity)
        {
            var documents = await UnitOfWork.Document.GetDocumentsByDocumentTypeId(entity.DocumentTypeId);
            var isExist = documents.FirstOrDefault(document =>
                document.Id == entity.Id
                && document.DocumentTypeId == entity.DocumentTypeId
                && document.Name == entity.Name
                && document.Number == entity.Number) != null;

            if (isExist)
            {
                return false;
            }
            await UnitOfWork.Document.Create(entity.ToDal());
            return true;
        }

        public async Task Update(DocumentBm entity)
        {
            var document = await UnitOfWork.Document.GetById(entity.Id);
            if (document != null)
            {
                await UnitOfWork.Document.Update(entity.ToDal());
            }
        }

        public async Task Delete(DocumentBm entity)
        {
            var document = await UnitOfWork.Document.GetById(entity.Id);
            if (document != null)
            {
                await UnitOfWork.Document.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<DocumentBm>> GetAll() =>
            (await UnitOfWork.Document.GetAll())
            .Select(document => document.ToBm());

        public async Task<DocumentBm> GetById(Guid id) =>
            (await UnitOfWork.Document.GetById(id)).ToBm();
    }
}
