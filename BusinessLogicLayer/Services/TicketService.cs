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
        private ITicketRepository Ticket { get; }

        public TicketService(ITicketRepository ticket)
        {
            Ticket = ticket;
        }

        public async Task<bool> Create(Ticket entity)
        {
            var tickets = (await Ticket.GetAll())
                .FirstOrDefault(
                    ticket =>
                        ticket.Id == entity.Id
                        && ticket.TicketNumber == entity.TicketNumber);
            var isExist = tickets != null;

            if (isExist)
            {
                return false;
            }

            await Ticket.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(Ticket entity)
        {
            var ticket = await Ticket.GetById(entity.Id);
            if (ticket != null)
            {
                await Ticket.Update(entity.ToEntity());
            }
        }

        public async Task Delete(Ticket entity)
        {
            var ticket = await Ticket.GetById(entity.Id);
            if (ticket != null)
            {
                await Ticket.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll() =>
            (await Ticket.GetAll()).Select(ticket => ticket.ToModel());

        public async Task<Ticket> GetById(Guid id) =>
            (await Ticket.GetById(id))?.ToModel();
    }
}
