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
            if (obj.Name== obj.Name.ToString())
            {
                ModelState.AddModelError("Name", "The UserName cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _databaseContex.Animals.Add(obj);
                _databaseContex.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Animal? animalFromDb = _databaseContex.Animals.Find(id);

            if (animalFromDb == null)
            {
                return NotFound();
            }

            return View(_databaseContex);
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

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Animal? animalFromDb = _databaseContex.Animals.Find(id);

            if (animalFromDb == null)
            {
                return NotFound();
            }

            return View(_databaseContex);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (ModelState.IsValid)
            {
                Animal obj = _databaseContex.Animals.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                _databaseContex.Animals.Remove(obj);
                _databaseContex.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    }
