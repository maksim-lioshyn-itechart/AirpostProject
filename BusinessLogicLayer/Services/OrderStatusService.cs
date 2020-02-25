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
        private IUnitOfWork UnitOfWork { get; }

        public OrderStatusService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(OrderStatusBm entity)
        {
            var airplanes = await UnitOfWork.OrderStatus.GetAll();
            if (airplanes.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.OrderStatus.Create(entity.ToDal());
            return true;
        }

        public async Task Update(OrderStatusBm entity)
        {
            var airplanes = await UnitOfWork.OrderStatus.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.OrderStatus.Update(entity.ToDal());
            }
        }

        public async Task Delete(OrderStatusBm entity)
        {
            var airplanes = await UnitOfWork.OrderStatus.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.OrderStatus.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<OrderStatusBm>> GetAll() =>
            (await UnitOfWork.OrderStatus.GetAll())
            .Select(a => a.ToBm());

        public async Task<OrderStatusBm> GetById(Guid id) =>
            (await UnitOfWork.OrderStatus.GetById(id)).ToBm();
    }
}
