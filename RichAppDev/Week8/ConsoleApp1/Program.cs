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
        var pet1 = new Pet { Name = "Buddy", User = user, Type = "Dog" };
        var pet2 = new Pet { Name = "Milo", User = user, Type = "Cat" };
        var vet = new Vet { Name = "Dr. Smith", Pets = new List<Pet> { pet1, pet2 } };

        dbContext.Users.Add(user);
        dbContext.Pets.AddRange(pet1, pet2);
        dbContext.Vets.Add(vet);
        dbContext.SaveChanges();


        // [LINQ Queries]

        //Selects Owner's Name from Pet
        var petsWithOwners = dbContext.Pets.Select(p => new { p.Name, Owner = p.User.Name }).ToList();

        //Selects all Vets
        var allVets = dbContext.Vets.ToList();

        //Selects Users with more than 1 Pet
        var usersWithMultiplePets = dbContext.Users
            .Where(u => u.Pets.Count > 1)
            .Select(u => new
            {
                u.Name,
                PetCount = u.Pets.Count
            })
            .ToList();
        foreach (var User in usersWithMultiplePets)
        {
            Console.WriteLine($"User: {User.Name}, Pet Count: {User.PetCount}");
        }

        //Checks all appointments for the pet with the name "Buddy"
        var petName = "Buddy";
        var appointmentsForPet = dbContext.Appointments
            .Where(a => a.Pet.Name == petName)
            .Select(a => new
            {
                a.Date,
                a.Description,
                PetName = a.Pet.Name,
                a.Pet.Type
            })
            .ToList();
        foreach (var appointment in appointmentsForPet)
        {
            Console.WriteLine($"Appointment for {appointment.PetName}: {appointment.Date} - {appointment.Description}");
        }

        //Selects all Users and Pets with Appointments
        var usersWithPetsAndAppointments = dbContext.Users
            .Select(u => new
            {
                u.Name,
                Pets = u.Pets.Select(p => new
                {
                    p.Name,
                    p.Type,
                    Appointments = p.Appointments.Select(a => new
                    {
                        a.Date,
                        a.Description
                    })
                    .ToList()
                }).ToList()
            })
            .ToList();

        foreach (var User in usersWithPetsAndAppointments)
        {
            Console.WriteLine($"User: {user.Name}");
            foreach (var pet in user.Pets)
            {
                Console.WriteLine($"  Pet: {pet.Name} ({pet.Type})");
                foreach (var appointment in pet.Appointments)
                {
                    Console.WriteLine($"    Appointment: {appointment.Date} - {appointment.Description}");
                }
            }
        }

    }
}
