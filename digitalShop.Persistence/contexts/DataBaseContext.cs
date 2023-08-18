using digitalShop.common.role;
using digitalShop.domain.entites.users;
using digitalShop.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.Persistence.contexts
{
    public class DataBaseContext : DbContext , application.Interfaces.IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) 
        { }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserInRole> userInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(item => item.Email).IsUnique();

            queryFilters(modelBuilder);
            

        }

        private void queryFilters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved); 
        }

        private void SeedRoles (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = UserRoles.Admin });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = UserRoles.Operator });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = UserRoles.Customer });
        }
    }
}
