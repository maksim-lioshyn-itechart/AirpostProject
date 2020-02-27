using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogicLayer.Mappers.CommonMapper;

namespace BusinessLogicLayer.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private IOrderStatusRepository OrderStatus { get; }

        public OrderStatusService(IOrderStatusRepository orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public async Task<bool> Create(OrderStatus entity)
        {
            var statuses = (await OrderStatus.GetAll())
                .FirstOrDefault(status => status.Name == entity.Name);
            var isExist = statuses != null;

            if (isExist)
            {
                return false;
            }

            await OrderStatus.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(OrderStatus entity)
        {
            var status = await OrderStatus.GetById(entity.Id);
            if (status != null)
            {
                await OrderStatus.Update(entity.ToEntity());
            }
        }

        public async Task Delete(OrderStatus entity)
        {
            var orderStatus = await OrderStatus.GetById(entity.Id);
            if (orderStatus != null)
            {
                await OrderStatus.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<OrderStatus>> GetAll() =>
            (await OrderStatus.GetAll())
            .Select(status => status.ToModel());

        public async Task<OrderStatus> GetById(Guid id) =>
            (await OrderStatus.GetById(id))?.ToModel();
    }
}
