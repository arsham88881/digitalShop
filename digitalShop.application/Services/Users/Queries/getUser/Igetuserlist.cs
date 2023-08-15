using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Queries.getUser
{
    public interface Igetuserlistservice
    {
           ResultGetUsersDTO excute(RequestGetUsersDTO request);
    }

}
