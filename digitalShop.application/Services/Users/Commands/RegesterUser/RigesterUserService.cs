using digitalShop.application.Interfaces;
using digitalShop.common;
using digitalShop.common.DTOClasses;
using digitalShop.domain.entites.users;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            try
            {
                ///////////////validation part 
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDTO<ResultRigesterUserDTO>()
                    {
                        IsSuccess = false,
                        message = "name is requred",
                        data = new ResultRigesterUserDTO
                        {
                            UserID = 0,
                        }
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDTO<ResultRigesterUserDTO>()
                    {
                        IsSuccess = false,
                        message = "email is requered",
                        data = new ResultRigesterUserDTO()
                        {
                            UserID = 0,
                        }
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDTO<ResultRigesterUserDTO>()
                    {
                        IsSuccess = false,
                        message = "password is requered",
                        data = new ResultRigesterUserDTO
                        {
                            UserID = 0,
                        }
                    };
                }
                if(request.Password != request.RePassword)
                {
                    return new ResultDTO<ResultRigesterUserDTO>()
                    {
                        IsSuccess = false,
                        message = "Password and RePassword not match",
                        data = new ResultRigesterUserDTO()
                        {
                            UserID = 0,
                        }
                    };
                }
                //////////////////////////end validation part
                PasswordHasher hasher = new PasswordHasher();
                var hashedPassword = hasher.HashPassword(request.Password);
                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = hashedPassword,
                    IsActive = true,
                };
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
            catch(Exception ex)
            {
                return new ResultDTO<ResultRigesterUserDTO>()
                {
                    IsSuccess = false,
                    message = ex.ToString(),
                    data = new ResultRigesterUserDTO()
                    {
                        UserID = 10101,
                    }
                };
            }
        }
    }
}
