using Microsoft.EntityFrameworkCore;
using Unique_Finder.Database.Entities;

namespace Unique_Finder.Database
{
    public class ApplicationContextUnique : DbContext
    {
        public DbSet<DatabaseTemplate> Codes { get; set; }

        public ApplicationContextUnique() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=Unique_Codes_db;Trusted_Connection=True;"
            );
        }
    }
}
