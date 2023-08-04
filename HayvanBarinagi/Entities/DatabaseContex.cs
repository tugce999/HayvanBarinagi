using HayvanBarinagi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Entities
{
    public class DatabaseContex : DbContext
    {
        public DatabaseContex()
        {
        }

        public DatabaseContex(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public object Users { get; internal set; }
    }
}
