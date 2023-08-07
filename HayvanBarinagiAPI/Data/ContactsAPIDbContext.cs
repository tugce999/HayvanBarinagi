using HayvanBarinagiAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagiAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact>Contacts { get; set; }
    }
}
