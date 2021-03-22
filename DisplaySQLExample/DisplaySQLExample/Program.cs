using System;
using System.Linq;

namespace DisplaySQLExample
{
    class Program
    {
        static void Main(string[] args)
        {

            //Add
            using (TestDBContext db = new TestDBContext())
            {
                User user1 = new User{Name = "Tom", Age = 33};
                User user2 = new User{Name="Alice", Age = 26};
            
                //Add
                db.Users.AddRange(user1,user2); // or db.Users.Add(user1);
                
                db.SaveChanges();
            }
            
            //getting
            using (TestDBContext db = new TestDBContext())
            {
                var users = db.Users.ToList();
            
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
                }
            }
            
            //editing
            using (TestDBContext db = new TestDBContext())
            {
                //getting first user
                User user = db.Users.FirstOrDefault();
            
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 20;
            
                    db.SaveChanges();
                }
            
                Console.WriteLine("\nAfter Editing");
            
                var users = db.Users.ToList();
            
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            //Delete
            using (TestDBContext db = new TestDBContext())
            {
                User user = db.Users.FirstOrDefault();
            
                if (user != null)
                {
                    db.Users.Remove(user);
            
                    db.SaveChanges();
                }
            
                Console.WriteLine("\nAfter delete");
            
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}
