using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ITicketRepository : IBaseRepository<TicketEntity>
    {
        Task<TicketEntity> GetBy(string ticketNumber);
    }
}