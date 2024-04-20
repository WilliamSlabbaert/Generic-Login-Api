using DataLayer.Entities;
using DataLayer.HelperModels;

namespace DataLayer.Repo.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int Id);
        Task<User> Get(Credentials credentials);

        Task Add(RegisterCredentials registerCredentials);
    }
}
