using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HayvanBarinagi.Models;
using Microsoft.EntityFrameworkCore;
using HayvanBarinagi.Data;
using HayvanBarinagi.Models.Entities;

namespace HayvanBarinagi.Controllers
{
    //[Authorize(Roles = "admin,manager")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContex _databaseContex;

        public AdminController(DatabaseContex databaseContex)
        {
            _databaseContex = databaseContex;
        }

        //[Authorize]
        public IActionResult Index()
        {
            List<User> objUserList = _databaseContex.Users.ToList();
            return View(objUserList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User obj)
        {
            if (obj.NameSurname == obj.NameSurname.ToString())
            {
                ModelState.AddModelError("NameSurneme", "The UserName cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _databaseContex.Users.Add(obj);
                _databaseContex.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id )
        {
            if(id==null|| id==0)
            {
                return NotFound();
            }

            User? userFromDb = _databaseContex.Users.Find(id);
            User? userFromDb1 = _databaseContex.Users.FirstOrDefault(u => u.Id == id );
            User? userFromDb2 = _databaseContex.Users.Where(u => u.Id == id).FirstOrDefault();

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(_databaseContex);
        }
        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (obj.NameSurname == obj.UserName.ToString())
            {
                ModelState.AddModelError("NameSurneme", "The UserName cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _databaseContex.Users.Add(obj);
                _databaseContex.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


    }

}
