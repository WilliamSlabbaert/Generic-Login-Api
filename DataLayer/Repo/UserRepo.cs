using DataLayer.Entities;
using DataLayer.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repo
{
    public class UserRepo : IUserRepo
    {
        private MySqlDataContext _context;
        public UserRepo(MySqlDataContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var items = await this._context.Users.ToListAsync();
            return items;
        }
        public async Task<User> Get(int Id)
        {
            var item = await this._context.Users.FirstOrDefaultAsync(s => s.Id == Id);
            return item;
        }
        public async Task<User> Get(string username, string password)
        {
            var item = await this._context.Users.FirstOrDefaultAsync(s => s.Username == username && s.Password == password);
            return item;
        }
    }
}
