using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class DocumentTypeRepository: IDocumentTypeRepository
    {
        private readonly IConfigurationFactory _configuration;
        public DocumentTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(DocumentType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertDocumentType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<DocumentType> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<DocumentType>("GetDocumentTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DocumentType>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<DocumentType>("GetAllDocumentTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(DocumentType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateDocumentType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteDocumentType", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
