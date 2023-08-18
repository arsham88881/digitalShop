using digitalShop.application.Interfaces;
using digitalShop.common;

namespace digitalShop.application.Services.Users.Queries.getUser
{
    public class getuserlistservice : Igetuserlistservice
    {
        private readonly IDataBaseContext _Context;
        public getuserlistservice(IDataBaseContext context)
        {
            _Context = context;
        }
        public ResultGetUsersDTO excute(RequestGetUsersDTO request)
        {
            var userList = _Context.users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.searchKey))
            {
                userList = userList.Where(p => p.FullName.Contains(request.searchKey) && p.Email.Contains(request.searchKey));
            }
            int rowcount = 0;
            var result = userList.ToPaged(request.page, 20, out rowcount).Select(p => new GetUserDTO
            {
                email = p.Email,
                name = p.FullName,
                IsActive = p.IsActive,
                id = p.Id,
            }).ToList();
            return new ResultGetUsersDTO
            {
                users = result,
                Rows = rowcount,
            };
        }
    }

}
