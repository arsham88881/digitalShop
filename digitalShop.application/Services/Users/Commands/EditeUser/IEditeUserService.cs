using digitalShop.application.Interfaces;
using digitalShop.common.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Commands.EditeUser
{
    public interface IEditeUserService
    {
        ResultDTO execute(long UserId);
    }
    public class EditeUserService : IEditeUserService
    {
        private readonly IDataBaseContext _context;
        public EditeUserService(IDataBaseContext baseContext)
        {
            _context = baseContext;
        }
        ResultDTO IEditeUserService.execute(long UserId)
        {
            throw new NotImplementedException();
        }
    }
    //complete edit user service and take role to one role migration and modifying every where

    public class RequestEditDTO
    {
        public long UserId { get; set;}
        public string UserName { get; set;}
        public int RoleId { get; set;}
    }

    
}
