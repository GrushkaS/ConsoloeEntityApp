using System;
using System.Linq;

namespace ConsoloeAppWithDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                User.User user1 = new User.User { name = "Tom", age = 33 };
                User.User user2 = new User.User { name = "Alice", age = 26 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User.User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.name} - {u.age}");
                }
            }
            Console.ReadKey();
        }
    }
}
