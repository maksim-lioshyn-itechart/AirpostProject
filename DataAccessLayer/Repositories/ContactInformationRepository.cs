using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using DataAccessLayer.Interfaces;
using ORM;
using ORM.Attributes;
using ORM.Models;

namespace DataAccessLayer.Repositories
{
    public class ContactInformationRepository: BaseRepository<ContactInformation>, IContactInformationRepository
    {
        public ContactInformationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<ContactInformation> GetContactInformationByUser(User user)
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return db.Query<ContactInformation>($"SELECT * FROM {TableName()} WHERE UserId = '{user.Id}'").ToList();
        }
    }
}
