using DataLayer.Entities;

namespace DataLayer.Repo.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int Id);
        Task<User> Get(string username, string password);
    }
}
