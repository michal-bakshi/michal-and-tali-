using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace webApi
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAB-D-16;Database=userDB;" +
               "User Id=DOMAIN\\seminar;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
    }
}
