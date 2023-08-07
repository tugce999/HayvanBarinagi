using HayvanBarinagi.Data;
using HayvanBarinagi.Models;
using HayvanBarinagi.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace HayvanBarinagi.Controllers
{
    [Authorize(Roles = "admin")]
    public class AnimalsController : Controller
    {
        private readonly DatabaseContex _databaseContex;

        public AnimalsController(DatabaseContex databaseContex)
        {
            _databaseContex = databaseContex;
        }

        //[Authorize]
        public IActionResult Index()
        {
            List<Animal> objAnimalList = _databaseContex.Animals.ToList();
            return View(objAnimalList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Animal obj)
        {
            
            
                _databaseContex.Animals.Add(obj);
                _databaseContex.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            
           
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Animal? databaseContex = _databaseContex.Animals.Find(id);

            if (databaseContex == null)
            {
                return NotFound();
            }

            return View(databaseContex);
        }
        [HttpPost]
        public IActionResult Edit(Animal obj)
        {

            if (ModelState.IsValid)
            {
                _databaseContex.Animals.Add(obj);
                _databaseContex.SaveChanges();
                TempData["success"] = "Animal created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Animal obj)
        {

            _databaseContex.Animals.Add(obj);
            _databaseContex.SaveChanges();
            TempData["success"] = "Animal deleted successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Listele()
        {
            List<Animal> objAnimalList = _databaseContex.Animals.ToList();
            return View(objAnimalList);
        }
        public IActionResult Sahiplen(int id)
        {
            Animal sahiplenilen = _databaseContex.Animals.FirstOrDefault(x => x.Id == id);
            sahiplenilen.sahip = User.Identity.Name;
            _databaseContex.Animals.Update(sahiplenilen);
            _databaseContex.SaveChanges(true);
            return  RedirectToAction("Index");
        }

        public IActionResult Listele2()
        {
            List<Animal> objAnimalList = _databaseContex.Animals.ToList();
            return View(objAnimalList);
        }
        public IActionResult Sahiplenilen(int sahiplenilen.Id)
        {
            Animal sahiplenilen = _databaseContex.Animals.FirstOrDefault(x =>x.sahip == sahiplenilen.Id);
            sahiplenilen.sahip = User.Identity.Name;
            _databaseContex.Animals.Update(sahiplenilen);
            _databaseContex.SaveChanges(true);
            return RedirectToAction("Index");
        }
    }
    }
