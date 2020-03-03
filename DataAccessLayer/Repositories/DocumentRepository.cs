using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IConfigurationFactory _configuration;

        public DocumentRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(DocumentEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertDocument", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<DocumentEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<DocumentEntity>("GetDocumentById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DocumentEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<DocumentEntity>("GetAllDocuments", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(DocumentEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateDocument", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteDocument", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DocumentEntity>> GetBy(Guid documentTypeId, bool isActive)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<DocumentEntity>("GetBy", new { documentTypeId, isActive }, commandType: CommandType.StoredProcedure);
        }
    }
}
