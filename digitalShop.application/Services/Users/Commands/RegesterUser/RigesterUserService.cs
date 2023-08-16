using digitalShop.application.Interfaces;
using digitalShop.common.DTOClasses;
using digitalShop.domain.entites.users;

namespace digitalShop.application.Services.Users.Commands.RegesterUser
{
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
}
