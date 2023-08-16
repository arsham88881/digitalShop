using digitalShop.application.Services.Users.Commands.RegesterUser;
using digitalShop.application.Services.Users.Queries.getRole;
using digitalShop.application.Services.Users.Queries.getUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        
        private readonly Igetuserlistservice _getuserlist;
        private readonly IRigesterUserService _rigesterUser;
        private readonly IgetRolesService _getRolesService;
        public AccountController(Igetuserlistservice getuserlist, IRigesterUserService rigesterUser, IgetRolesService getRolesService)
        {
            _getuserlist = getuserlist;
            _rigesterUser = rigesterUser;
            _getRolesService = getRolesService;
        }
        public IActionResult Index(string searchkey,int page=1)
        {
            return View(_getuserlist.excute(new RequestGetUsersDTO
            {
                page = page,
                searchKey = searchkey,
            }));
        }
        //[HttpGet]
        public IActionResult Create() {
           ViewBag.roles = new SelectList(_getRolesService.Execute().data, "Id", "Name"); //in html tag defined value tag : id and defined tage name : name
            return View();
        }
    }
}
