using HayvanBarinagi.Data;
using HayvanBarinagi.Models;
using HayvanBarinagi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContex databaseContex;
        public UsersController(DatabaseContex databaseContex) 
        {
            this.databaseContex = databaseContex;

        }
        
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var users = await databaseContex.Users.ToListAsync();
            return View(users);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult >Add(AddUserViwModel addUserRequest)
        {
            var user = new User()
            {

                NameSurname = addUserRequest.NameSurname,
                UserName = addUserRequest.UserName,
                CreatedAdd = addUserRequest.CreatedAdd,
                Password = addUserRequest.Password,
                Role = addUserRequest.Role
            };
            await databaseContex.Users.AddAsync(user);
            await databaseContex.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult View(int id)
        {
            var user = databaseContex.Users.FirstOrDefaultAsync(x => x.Id == id);

            return View(user);
        }
    }
}
