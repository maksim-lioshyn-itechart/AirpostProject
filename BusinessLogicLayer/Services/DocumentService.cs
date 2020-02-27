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
        private IDocumentRepository Document { get; }

        public DocumentService(IDocumentRepository document)
        {
            Document = document;
        }

        public async Task<bool> Create(Document entity)
        {
            var documents = (await Document.GetDocumentsByDocumentTypeId(entity.DocumentTypeId))
                .FirstOrDefault(
                    document =>
                        document.Id == entity.Id
                        && document.DocumentTypeId == entity.DocumentTypeId
                        && document.Name == entity.Name
                        && document.Number == entity.Number);
            var isExist = documents != null;

            if (isExist)
            {
                return false;
            }

            await Document.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(Document entity)
        {
            var document = await Document.GetById(entity.Id);
            if (document != null)
            {
                await Document.Update(entity.ToEntity());
            }
        }

        public async Task Delete(Document entity)
        {
            var document = await Document.GetById(entity.Id);
            if (document != null)
            {
                await Document.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<Document>> GetAll() =>
            (await Document.GetAll())
            .Select(document => document.ToModel());

        public async Task<Document> GetById(Guid id) =>
            (await Document.GetById(id))?.ToModel();
    }
}
