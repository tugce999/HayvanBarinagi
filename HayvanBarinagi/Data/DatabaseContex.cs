using HayvanBarinagi.Models;
using HayvanBarinagi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Data
{
    public class DatabaseContex : DbContext
    {


        public DatabaseContex(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
     

    }
    
    }

