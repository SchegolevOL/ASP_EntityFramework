using Microsoft.EntityFrameworkCore;

namespace ASP_EntityFramework.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
    // в командной строке набрать для создания базы данных

    // cd.\
    // dotnet ef migrations add Init
    // dotnet ef database update
}
