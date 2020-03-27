using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ITicketRepository : IBaseRepository<TicketEntity>
    {
        Task<TicketEntity> GetBy(string ticketNumber);
    }
}