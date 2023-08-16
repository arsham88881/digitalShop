using digitalShop.application.Interfaces;
using digitalShop.common.DTOClasses;

namespace digitalShop.application.Services.Users.Queries.getRole
{
    public class GetRolesService : IgetRolesService
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<RolesDto>> Execute()
        {
            var roles = _context.roles.ToList().Select(p => new RolesDto
            {
                Id = p.ID,
                Name = p.Name
            }).ToList();

            return new ResultDTO<List<RolesDto>>()
            {
                data = roles,
                IsSuccess = true,
                message = "",
            };
        }
    }
}
