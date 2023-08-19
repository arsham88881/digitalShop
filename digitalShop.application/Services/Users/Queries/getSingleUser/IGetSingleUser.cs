using digitalShop.application.Interfaces;
using digitalShop.application.Services.Users.Commands.EditeUser;
using digitalShop.application.Services.Users.Commands.RegesterUser;
using digitalShop.common.DTOClasses;
using digitalShop.domain.entites.users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Queries.getSingleUser
{
    public interface IGetSingleUser
    {
        ResultDTO<ResultSingleUserDTO> execute(long UserId);
    }
    public class GetSingleUser : IGetSingleUser
    {
        private readonly IDataBaseContext _context;
        public GetSingleUser(IDataBaseContext baseContext)
        {
            _context = baseContext;
        }

        public ResultDTO<ResultSingleUserDTO> execute(long UserId)
        {
            try
            {
                var user = _context.users.FirstOrDefault(p => p.Id == UserId);
                var userinROR = _context.userInRoles.FirstOrDefault(p => p.UserId == UserId);
                return new ResultDTO<ResultSingleUserDTO>()
                {
                    IsSuccess = true,
                    message = "",
                    data = new ResultSingleUserDTO()
                    {
                        UserName = user.FullName,
                        roles = userinROR.RoleID,
                    }
                };
            }
            catch(Exception ex)
            {
                return new ResultDTO<ResultSingleUserDTO>()
                {
                    IsSuccess = false,
                    message = ex.Message,
                    
                };
            }
        }
    }
    public class ResultSingleUserDTO {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long roles { get; set; }
    }
}
