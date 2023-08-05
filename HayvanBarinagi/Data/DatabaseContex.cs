using HayvanBarinagi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Data
{
    public class DatabaseContex : DbContext
    {


        public DatabaseContex(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hayvan> Animals { get; set; }
        public DbSet<Tur> Tür { get; set; }
        public DbSet<Cins> Cins { get; set; }
        public DbSet<OwnedType> OwnedType { get; set; }
    }
}
