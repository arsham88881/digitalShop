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


    }
}
