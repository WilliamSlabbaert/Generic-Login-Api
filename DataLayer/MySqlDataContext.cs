using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MySqlDataContext : DbContext
    {
        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
