using DataLayer.Repo.Interfaces;

namespace DataLayer.Repo
{
    public class UserRepo : IUserRepo
    {
        private MySqlDataContext _context;
        public UserRepo(MySqlDataContext context)
        {
            this._context = context;
        }

        public void Get()
        {
            var items = this._context.Users.ToList();
        }
    }
}
