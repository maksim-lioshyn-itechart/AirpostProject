using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;
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

        public async Task<StatusCode> Create(OrderStatus entity)
        {
            var statuses = await OrderStatus.GetBy(entity.Name);
            var isExist = statuses != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await OrderStatus.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(OrderStatus entity)
        {
            var status = await OrderStatus.GetById(entity.Id);
            if (status != null)
            {
                await OrderStatus.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(OrderStatus entity)
        {
            var orderStatus = await OrderStatus.GetById(entity.Id);
            if (orderStatus != null)
            {
                await OrderStatus.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<OrderStatus>> GetAll() =>
            (await OrderStatus.GetAll())
            .Select(status => status.ToModel());

        public async Task<OrderStatus> GetById(Guid id) =>
            (await OrderStatus.GetById(id))?.ToModel();
    }
}
