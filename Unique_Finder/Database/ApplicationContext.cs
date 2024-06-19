using Microsoft.EntityFrameworkCore;
using Unique_Finder.Database.Entities;

namespace Unique_Finder.Database
{
    public class DatabaseContextUnique : DbContext
    {
        public DbSet<DatabaseTemplate> UniqueCodes { get; set; } = null!;

        public DatabaseContextUnique() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=unique_db;Trusted_Connection=True;"
            );
        }
    }
}
