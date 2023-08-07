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
          
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(_databaseContex);
        }
        [HttpPost]
        public IActionResult Edit(User obj)
        {
          
            if (ModelState.IsValid)
            {
                _databaseContex.Users.Add(obj);
                _databaseContex.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            User? userFromDb = _databaseContex.Users.Find(id);
          
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(_databaseContex);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (ModelState.IsValid)
            {
                User obj = _databaseContex.Users.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                _databaseContex.Users.Remove(obj);
                _databaseContex.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IEnumerable<User> tugce()
        {
            var tugce = from n in _databaseContex.Users.Where(n => n.UserName == "tugce")
                        select n;
            return tugce.ToList();
        }
    }

}
