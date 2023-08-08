using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HayvanBarinagi.Data;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Models
{
    [Table("Animals")]
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen isim giriniz")]
        [Display(Name = "İsmi")]
        public string ?Name { get; set; }

        public string sahip { get; set; }

        [Display(Name = "Cinsiyet")]
        public string  ?GenderType { get; set; }

        [Required(ErrorMessage = "Lütfen yaşını giriniz")]
        [Display(Name = "Yaş")]
        public string  ?Age { get; set; }

       

        [Required(ErrorMessage = "Lütfen rengini giriniz")]
        [Display(Name = "Renk")]
        public string ?Color { get; set; }

    }


public static class AnimalEndpoints
{
	public static void MapAnimalEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Animal", async (DatabaseContex db) =>
        {
            return await db.Animals.ToListAsync();
        })
        .WithName("GetAllAnimals")
        .Produces<List<Animal>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Animal/{id}", async (int Id, DatabaseContex db) =>
        {
            return await db.Animals.FindAsync(Id)
                is Animal model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetAnimalById")
        .Produces<Animal>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Animal/{id}", async (int Id, Animal animal, DatabaseContex db) =>
        {
            var foundModel = await db.Animals.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(animal);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateAnimal")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Animal/", async (Animal animal, DatabaseContex db) =>
        {
            db.Animals.Add(animal);
            await db.SaveChangesAsync();
            return Results.Created($"/Animals/{animal.Id}", animal);
        })
        .WithName("CreateAnimal")
        .Produces<Animal>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Animal/{id}", async (int Id, DatabaseContex db) =>
        {
            if (await db.Animals.FindAsync(Id) is Animal animal)
            {
                db.Animals.Remove(animal);
                await db.SaveChangesAsync();
                return Results.Ok(animal);
            }

            return Results.NotFound();
        })
        .WithName("DeleteAnimal")
        .Produces<Animal>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
    
}
