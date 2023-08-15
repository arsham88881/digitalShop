using digitalShop.application.Services.Users.Queries.getUser;
using Microsoft.AspNetCore.Mvc;

namespace endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        
        private readonly Igetuserlistservice _getuserlist;
        public AccountController(Igetuserlistservice getuserlist)
        {
            _getuserlist = getuserlist;
        }
        public IActionResult Index(string searchkey,int page=1)
        {
            return View(_getuserlist.excute(new RequestGetUsersDTO
            {
                page = page,
                searchKey = searchkey,
            }));
        }
    }
}
