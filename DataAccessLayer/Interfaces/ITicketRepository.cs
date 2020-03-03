using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ITicketRepository : IBaseRepository<TicketEntity>
    {
        Task<IEnumerable<TicketEntity>> GetBy(string ticketNumber);
    }
}