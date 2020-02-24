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
    public class OrderStatusRepository: IOrderStatusRepository
    {
        private readonly IConfigurationFactory _configuration;
        public OrderStatusRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(OrderStatus entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertOrderStatus", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<OrderStatus> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<OrderStatus>("GetOrderStatusById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OrderStatus>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<OrderStatus>("GetAllOrderStatuses", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(OrderStatus entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateOrderStatus", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteOrderStatus", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
