using ClassLibrary;
//using ClassLibrary.Data;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var dbContext = new AppDbContext();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        // Seed data
        var user = new User { Name = "Alice", Pets = new List<Pet>() };
        var pet1 = new Pet { Name = "Buddy", User = user };
        var pet2 = new Pet { Name = "Milo", User = user };
        var vet = new Vet { Name = "Dr. Smith", Pets = new List<Pet> { pet1, pet2 } };

        dbContext.Users.Add(user);
        dbContext.Pets.AddRange(pet1, pet2);
        dbContext.Vets.Add(vet);
        dbContext.SaveChanges();

        // LINQ Queries
        var petsWithOwners = dbContext.Pets.Select(p => new { p.Name, Owner = p.User.Name }).ToList();
        var allVets = dbContext.Vets.ToList();
    }
}
