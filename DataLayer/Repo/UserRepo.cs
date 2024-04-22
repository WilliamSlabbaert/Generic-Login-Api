using DataLayer.Entities;
using DataLayer.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly MySqlDataContext _context;
        private readonly DbSet<User> _userSet;
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
        public async Task<User> Get(string username)
        {
            var item = await this._userSet.FirstOrDefaultAsync(s => s.Username == username);
            return item;
        }

        public async Task Add(User user)
        {
            await this._userSet.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
