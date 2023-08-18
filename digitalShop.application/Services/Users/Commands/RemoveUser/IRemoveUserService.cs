using digitalShop.application.Interfaces;
using digitalShop.common.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDTO execute(long UserId);
    }
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public ResultDTO execute(long UserId)
        {
            var user = _context.users.Find(UserId);
            if(user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    message = "user not find",
                };
            }
            user.IsRemoved = true;
            user.RemovedTime = DateTime.Now;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                message = " successfully removed ",
            };
        }
    }
}
