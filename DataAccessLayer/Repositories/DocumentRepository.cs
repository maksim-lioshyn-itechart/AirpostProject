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

        public async Task Create(Document entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertDocument", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Document> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<Document>("GetDocumentById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Document>("GetAllDocuments", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Document entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateDocument", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteDocument", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
