using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserContactInformationRepository : IBaseRepository<UserContactInformation>
    {
        IEnumerable<UserContactInformation> GetUserContactInformation(User user);
    }
}