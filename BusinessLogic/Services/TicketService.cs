﻿using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private ITicketRepository Ticket { get; }

        public TicketService(ITicketRepository ticket)
        {
            Ticket = ticket;
        }

        public async Task<StatusCode> Create(Ticket entity)
        {
            Validation(entity);
            var tickets = await Ticket.GetBy(entity.TicketNumber);
            var isExist = tickets != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await Ticket.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Ticket entity)
        {
            var ticket = await Ticket.GetById(entity.Id);
            if (ticket != null)
            {
                Validation(entity);
                await Ticket.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Ticket entity)
        {
            var ticket = await Ticket.GetById(entity.Id);
            if (ticket != null)
            {
                await Ticket.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Ticket>> GetAll() =>
            (await Ticket.GetAll()).Select(ticket => ticket.ToModel());

        public async Task<Ticket> GetById(Guid id) =>
            (await Ticket.GetById(id))?.ToModel();

        private void Validation(Ticket entity)
        {

        }
    }
}
