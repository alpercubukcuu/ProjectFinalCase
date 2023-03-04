using Core.Domain.Entities.Categories;
using Core.Domain.Entities.Products;
using Core.Domain.Entities.Projects;
using Core.Domain.Entities.Roles;
using Core.Domain.Entities.Shops;
using Core.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-Q3H4FFS; database=PatikaFinalCase; Integrated Security = true; TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }       
        public DbSet<Project> Projects { get; set; }

        public DbSet<Shops> Shops { get; set; }
    }
}
