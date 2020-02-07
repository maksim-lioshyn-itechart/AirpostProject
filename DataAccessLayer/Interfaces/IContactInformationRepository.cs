using System.Collections.Generic;
using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IContactInformationRepository : IBaseRepository<ContactInformation>
    {
        List<ContactInformation> GetContactInformationByUser(User user);
    }
}