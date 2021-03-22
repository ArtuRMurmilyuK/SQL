using System;
using Microsoft.EntityFrameworkCore;

namespace CityExample
{
    class Program
    {
        static void Main()
        {
            using (AppContext context = new AppContext())
            {
                context.Users.Add(new User() {Name = "Vitalii", Age = 22});

                context.SaveChanges();
            }
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =(localdb)\\mssqllocaldb; Database=TestDB; Trusted_Connection =True");
        }
    }
}
