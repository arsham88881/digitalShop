using digitalShop.common.DTOClasses;
using digitalShop.domain.entites.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Queries.getRole
{
    public interface IgetRolesService
    {
        ResultDTO<List<RolesDto>> Execute();
    }
}
