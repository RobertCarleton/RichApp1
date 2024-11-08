using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentClassLibrary.Models;
using System.Xml.Linq;

namespace StudentConsoleApp.Data
{
    internal class ConsoleDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=C:\\Users\\Robert C\\Documents\\" +
                $"GitHub\\RichApp1\\RichAppDev\\W6L1\\StudentConsoleApp\\students.db");
        }
    }
}
