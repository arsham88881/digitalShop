using digitalShop.domain.entites.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Interfaces
{
    public interface IDataBaseContext
    {
        DbSet<User> users { get; set; }
        DbSet<Role> roles { get; set; }
        DbSet<UserInRole> userInRoles { get; set; }

        int SaveChanges(bool AccepAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
