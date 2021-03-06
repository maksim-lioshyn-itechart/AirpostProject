﻿using BusinessLogic.Enums;
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
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDocumentTypeRepository DocumentType { get; }

        public DocumentTypeService(IDocumentTypeRepository documentType)
        {
            DocumentType = documentType;
        }

        public async Task<StatusCode> Create(DocumentType entity)
        {
            Validation(entity);
            var types = await DocumentType.GetBy(entity.Name);
            var isExist = types != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await DocumentType.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(DocumentType entity)
        {
            var type = await DocumentType.GetById(entity.Id);
            if (type != null)
            {
                Validation(entity);
                await DocumentType.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(DocumentType entity)
        {
            var type = await DocumentType.GetById(entity.Id);
            if (type != null)
            {
                await DocumentType.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<DocumentType>> GetAll() =>
            (await DocumentType.GetAll())
            .Select(type => type.ToModel());

        public async Task<DocumentType> GetById(Guid id) =>
            (await DocumentType.GetById(id))?.ToModel();

        private void Validation(DocumentType entity)
        {
            var validator = new Validator<DocumentType>();
            validator.IsValidName(entity.Name);
        }
    }
}
