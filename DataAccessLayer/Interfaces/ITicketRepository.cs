using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ITicketRepository : IBaseRepository<TicketEntity>
    {
        Task<TicketEntity> GetBy(string ticketNumber);
    }
}