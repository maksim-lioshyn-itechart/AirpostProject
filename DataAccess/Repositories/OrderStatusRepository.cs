using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly IConfigurationFactory _configuration;

        public OrderStatusRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(OrderStatusEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertOrderStatus", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<OrderStatusEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<OrderStatusEntity>("GetOrderStatusById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OrderStatusEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<OrderStatusEntity>("GetAllOrderStatuses", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(OrderStatusEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateOrderStatus", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteOrderStatus", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<OrderStatusEntity> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<OrderStatusEntity>("GetOrderStatusesBy", new { name }, commandType: CommandType.StoredProcedure);
        }
    }
}
