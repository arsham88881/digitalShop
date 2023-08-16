using digitalShop.common.role;
using digitalShop.domain.entites.users;
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
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Name = UserRoles.Admin });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Name = UserRoles.Operator});
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Name = UserRoles.Customer});

        }
    }
}
