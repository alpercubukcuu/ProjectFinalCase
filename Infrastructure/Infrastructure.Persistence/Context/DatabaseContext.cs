using Core.Domain.Entities.Roles;
using Core.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
