using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Enums;

namespace BusinessLogic.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository Document { get; }

        public DocumentService(IDocumentRepository document)
        {
            Document = document;
        }

        public async Task<StatusCode> Create(Document entity)
        {
            var documents = await Document.GetBy(entity.DocumentTypeId, entity.Name, entity.Number);
            var isExist = documents != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await Document.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Document entity)
        {
            var document = await Document.GetById(entity.Id);
            if (document != null)
            {
                await Document.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Document entity)
        {
            var document = await Document.GetById(entity.Id);
            if (document != null)
            {
                await Document.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Document>> GetAll() =>
            (await Document.GetAll())
            .Select(document => document.ToModel());

        public async Task<Document> GetById(Guid id) =>
            (await Document.GetById(id))?.ToModel();
    }
}
