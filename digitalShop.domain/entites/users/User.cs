using digitalShop.domain.entites.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.domain.entites.users
{
    public class User :BaseOption
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set;}
    }
}
