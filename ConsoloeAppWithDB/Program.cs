using System;
using System.Linq;

namespace ConsoloeAppWithDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region write data
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // создаем два объекта User
            //    User.User user1 = new User.User { name = "Tom", age = 33 };
            //    User.User user2 = new User.User { name = "Alice", age = 26 };

            //    // добавляем их в бд
            //    db.Users.Add(user1);
            //    db.Users.Add(user2);
            //    db.SaveChanges();
            //    Console.WriteLine("Объекты успешно сохранены");

            //    // получаем объекты из бд и выводим на консоль
            //    var users = db.Users.ToList();
            //    Console.WriteLine("Список объектов:");
            //    foreach (User.User u in users)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.name} - {u.age}");
            //    }
            //}
            #endregion

            #region read data
            //using (testappdbContext db = new testappdbContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var users = db.Users.ToList();
            //    Console.WriteLine("Список объектов:");
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //    }
            //}
            #endregion

            //Actual working
            #region Add data
            using (testappdbContext db = new testappdbContext())
            {
                User us1 = new User { Name = "Vadim", Age = 21 };
                User us2 = new User { Name = "Vlad", Age = 3 };
                User us3 = new User { Name = "Eugen", Age = 33 };

                db.Users.Add(us1);
                db.Users.Add(us2);
                db.Users.Add(us3);
                db.SaveChanges();

                Console.WriteLine("Users added");
            }
            #endregion
            #region reading data
            using (testappdbContext db = new testappdbContext())
            {
                Console.WriteLine("Reading users");

                var users = db.Users.ToList();

                foreach(User us in users)
                {
                    Console.WriteLine($"{us.Id}){us.Name} - {us.Age}");
                }
                
            }
            #endregion

            #region edit user
            using (testappdbContext db = new testappdbContext())
            {
                Console.WriteLine("Input id of user to edit:");
                int a = int.Parse(Console.ReadLine());
                //User user = db.Users.FirstOrDefault();
                User user = db.Users.ToList()[a-1];
                user.Name = "Bob";
                user.Age = 55;
                db.Users.Update(user);
                db.SaveChanges();
                //if (user != null)
                //{
                //    user.Name = "Bob";
                //    user.Age = 44;
                    
                //    db.Users.Update(user);
                //    db.SaveChanges();
                //}
                
                Console.WriteLine("\nAfter edit:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}){u.Name} - {u.Age}");
                }
            }
            #endregion

            #region remove user
            using (testappdbContext db = new testappdbContext())
            {
                Console.WriteLine("Input id of user to remove:");
                int a = int.Parse(Console.ReadLine());
                //User user = db.Users.FirstOrDefault();
                User user = db.Users.ToList()[a - 1];

                db.Users.Remove(user);
                db.SaveChanges();
                
                Console.WriteLine("\nAfter edit:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}){u.Name} - {u.Age}");
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
