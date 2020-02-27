using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IConfigurationFactory _configuration;

        public DocumentTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(DocumentTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertDocumentType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<DocumentTypeEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<DocumentTypeEntity>("GetDocumentTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DocumentTypeEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<DocumentTypeEntity>("GetAllDocumentTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(DocumentTypeEntity entity)
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
