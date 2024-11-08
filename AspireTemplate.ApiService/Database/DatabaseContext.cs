using Microsoft.EntityFrameworkCore;

namespace AspireTemplate.ApiService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> People { get; set; }
    }
}