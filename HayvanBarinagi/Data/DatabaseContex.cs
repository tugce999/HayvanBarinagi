using HayvanBarinagi.Models;
using HayvanBarinagi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace HayvanBarinagi.Data
{
    public class DatabaseContex : DbContext
    {


        public DatabaseContex(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal>Animals { get; set; }



    }
     
    }

