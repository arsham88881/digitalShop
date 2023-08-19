using digitalShop.application.Interfaces;
using digitalShop.application.Services.Users.Commands.RegesterUser;
using digitalShop.common.DTOClasses;
using digitalShop.domain.entites.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Commands.EditeUser
{
    public interface IEditeUserService
    {
        ResultDTO execute(RequestEditDTO request);
    }
    public class EditeUserService : IEditeUserService
    {
        private readonly IDataBaseContext _context;
        public EditeUserService(IDataBaseContext baseContext)
        {
            _context = baseContext;
        }
        ResultDTO IEditeUserService.execute(RequestEditDTO request)
        {
            try
            {
                var user = _context.users.FirstOrDefault(en => en.Id == request.UserId);

                List<UserInRole> userInRoles = new List<UserInRole>();

                foreach (var item in request.roles) //in request I get list of roles for on user;
                {
                    var role = _context.roles.Find(item.ID);
                    userInRoles.Add(new UserInRole
                    {
                        Role = role,
                        RoleID = item.ID,
                        User = user,
                        UserId = user.Id
                    });
                }
                user.UpdateTime = DateTime.Now;
                user.FullName = request.UserName;
                user.UserInRoles = userInRoles;
                _context.SaveChanges();
                return new ResultDTO()
                {
                    IsSuccess = true,
                    message = "successfully editing",
                };
            }catch(Exception ex)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    message = ex.Message,
                };
            }
            
        }
    }
    //complete edit user service and take role to one role migration and modifying every where

    public class RequestEditDTO
    {
        public long UserId { get; set;}
        public string UserName { get; set; }
        public List<RolesInRigesterUserDTO> roles { get; set;}
    }
    
}
