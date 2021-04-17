using Microsoft.EntityFrameworkCore;
//using ConsoloeAppWithDB.User;

namespace ConsoloeAppWithDB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ConsoloeAppWithDB.User.User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testappdb;Trusted_Connection=True;");
        }
    }
}