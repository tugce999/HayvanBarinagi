using HayvanBarinagiAPI.Data;
using HayvanBarinagiAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagiAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;
        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(dbContext.Contacts.ToListAsync());
          
        }
        [HttpPost]
        public async Task<IActionResult >AddContacts(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Adress = addContactRequest.Adress,
                Email = addContactRequest.Email,
                NameSurname = addContactRequest.NameSurname,
                Phone = addContactRequest.Phone
            };
           await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);

        }
    }
}
