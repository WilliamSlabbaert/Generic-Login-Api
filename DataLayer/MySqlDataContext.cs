using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MySqlDataContext : DbContext
    {
        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options)
        {
            var Cstring = "Server=localhost;port=3306;Database=generic-authenticator;Uid=root;Pwd=coolmen15;";
        }

        public DbSet<User> Users { get; set; }
    }
}
