using digitalShop.application.Interfaces;
using digitalShop.common.DTOClasses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Commands.Change_status
{
    public interface IChangeStatusUserService
    {
        ResultDTO execute(long UserId);
    }
    public class ChangeStatusUserService : IChangeStatusUserService
    {
        private readonly IDataBaseContext _context;
        public ChangeStatusUserService(IDataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public ResultDTO execute(long UserId)
        {
            var user = _context.users.Find(UserId);
            if (user == null)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    message = "font found user ",
                };
            }
            user.IsActive =  !user.IsActive;
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
                message = "successfully change status",
            };
            
        }
    }
}
