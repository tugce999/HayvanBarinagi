using HayvanBarinagi.Data;
using HayvanBarinagi.Models;
using HayvanBarinagi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsAPIController : ControllerBase
    {
         private readonly DatabaseContex _databaseContex;

         public AnimalsAPIController(DatabaseContex databaseContex)
         {
             _databaseContex = databaseContex;

         }
         [HttpGet]

         public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
         {
             if (_databaseContex.Animals == null)
             {
                 return NotFound();
             }
             return await _databaseContex.Animals.ToListAsync();
         }
         [HttpGet("{id}")]

         public async Task<ActionResult<Animal>> GetAnimal(int id)
         {
             if (_databaseContex.Animals == null)
             {
                 return NotFound();
             }
             var animal = await _databaseContex.Animals.FindAsync(id);
             if (animal == null)
             {
                 return NotFound();
             }
             return animal;
         }

         [HttpPost]

         public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
         {
             _databaseContex.Animals.Add(animal);
             await _databaseContex.SaveChangesAsync();

             return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
         }

         [HttpPut]

         public async Task<ActionResult> PutAnimal(int id, Animal animal)
         {
             if (id != animal.Id)
             {
                 return BadRequest();

             }
             _databaseContex.Entry(animal).State = EntityState.Modified;

             try
             {
                 await _databaseContex.SaveChangesAsync();

             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!AnimalAvailable(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }

             }
             return Ok();
         }

         private bool AnimalAvailable(int id)
         {
             return (_databaseContex.Animals?.Any(x => x.Id == id)).GetValueOrDefault();
         }

         [HttpDelete("{id}")]

         public async Task<IActionResult> DeleteAnimal (int id)
         {
             if(_databaseContex.Animals == null)
             {
                 return NotFound();
             }
             var animal = await _databaseContex.Animals.FindAsync(id);
             if(animal ==null)
             {
                 return NotFound();
             }

             _databaseContex.Animals.Remove(animal);

             await _databaseContex.SaveChangesAsync();

             return Ok();
         }

       


       

        }
}