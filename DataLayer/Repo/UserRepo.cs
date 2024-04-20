using DataLayer.Entities;
using DataLayer.HelperModels;
using DataLayer.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repo
{
    public class UserRepo : IUserRepo
    {
        private MySqlDataContext _context;
        private DbSet<User> _userSet;
        public UserRepo(MySqlDataContext context)
        {
            this._context = context;
            this._userSet = context.Users;
        }
        public async Task<IEnumerable<User>> Get()
        {
            var items = await this._userSet.ToListAsync();
            return items;
        }
        public async Task<User> Get(int Id)
        {
            var item = await this._userSet.FirstOrDefaultAsync(s => s.Id == Id);
            return item;
        }
        public async Task<User> Get(Credentials credentials)
        {
            var item = await this._userSet.FirstOrDefaultAsync(s => s.Username == credentials.Username && s.Password == credentials.Password);
            return item;
        }

        public Task Add(RegisterCredentials registerCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
