using digitalShop.application.Interfaces;
using digitalShop.common.DTOClasses;
using digitalShop.domain.entites.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Commands.RegesterUser
{
    internal interface IRigesterUserService
    {
        ResultDTO<ResultRigesterUserDTO> execute(RequestRigesterServiceDTO request);
    }
    public class RigesterUserService : IRigesterUserService
    {
        private readonly IDataBaseContext _context;
        public RigesterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultRigesterUserDTO> execute(RequestRigesterServiceDTO request)
        {
            User user= new User()
            {
                Email = request.Email,
                FullName = request.FullName,
                ///password not working 
            };   
            List<UserInRole> userInRoles = new List<UserInRole>();

            foreach(var item in request.roles) //in request I get list of roles for on user;
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
            user.UserInRoles = userInRoles;
            _context.users.Add(user);
            _context.SaveChanges();

            return new ResultDTO<ResultRigesterUserDTO>()
            {
                IsSuccess = true,
                message = string.Format("ثبت نام با موفقیت انجام شد"),
                data = new ResultRigesterUserDTO()
                {
                    UserID = user.Id,
                }
               
            };
        }
    }
    public class RequestRigesterServiceDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public List<RolesInRigesterUserDTO> roles { get; set; }
    }
    public class RolesInRigesterUserDTO
    {
        public long ID { get; set; }
    }
    public class ResultRigesterUserDTO
    {
        public long UserID { get; set; }
    }
}
