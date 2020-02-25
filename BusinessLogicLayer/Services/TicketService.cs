using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TicketService : ITicketService
    {
        private IUnitOfWork UnitOfWork { get; }

        public TicketService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(TicketBm entity)
        {
            var tickets = await UnitOfWork.Ticket.GetAll();
            var isExist = tickets.FirstOrDefault(ticket =>
                              ticket.Id == entity.Id
                              && ticket.TicketNumber == entity.TicketNumber) != null;

            if (isExist)
            {
                return false;
            }

            await UnitOfWork.Ticket.Create(entity.ToDal());
            return true;
        }

        public async Task Update(TicketBm entity)
        {
            var ticket = await UnitOfWork.Ticket.GetById(entity.Id);
            if (ticket != null)
            {
                await UnitOfWork.Ticket.Update(entity.ToDal());
            }
        }

        public async Task Delete(TicketBm entity)
        {
            var ticket = await UnitOfWork.Ticket.GetById(entity.Id);
            if (ticket != null)
            {
                await UnitOfWork.Ticket.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<TicketBm>> GetAll() =>
            (await UnitOfWork.Ticket.GetAll()).Select(ticket => ticket.ToBm());

        public async Task<TicketBm> GetById(Guid id) =>
            (await UnitOfWork.Ticket.GetById(id)).ToBm();
    }
}
