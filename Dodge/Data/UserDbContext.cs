
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Dodge.Data
{
    class UserDbContext : DbContext
    {
        private string CONNECTION_STRING = ConfigurationManager.AppSettings["ConnectionString"];
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
