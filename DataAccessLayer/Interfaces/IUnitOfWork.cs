namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        void Saving(string sqlQuery);
    }
}