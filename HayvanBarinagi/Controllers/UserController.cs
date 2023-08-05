using AutoMapper;
using HayvanBarinagi.Data;
using HayvanBarinagi.Entities;
using HayvanBarinagi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HayvanBarinagi.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContex _databaseContex;
        private readonly IMapper mapper;

        public UserController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public UserController(DatabaseContex databaseContex)
        {
            _databaseContex = databaseContex;
        }

        public IActionResult Index()
        {
            List<User> users = _databaseContex.Users.ToList();
            List<UserModel> models = users.Select(x => mapper.Map<UserModel>(x)).ToList();
          
            return View(users);
        }
    }
}
