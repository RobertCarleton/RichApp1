using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class User // Represents a person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pet> Pets { get; set; } // One-to-many
    }

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }

    public class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pet> Pets { get; set; } // one-to-many
    }

    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PetId { get; set; } // Foreign Key
        public Pet Pet { get; set; }
    }

    public class AppUser : IdentityUser
    {
        public ICollection<Pet> Pets { get; set; }
    }
}
