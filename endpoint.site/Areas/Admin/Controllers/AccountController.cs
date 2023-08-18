using digitalShop.application.Services.Users.Commands.RegesterUser;
using digitalShop.application.Services.Users.Queries.getRole;
using digitalShop.application.Services.Users.Queries.getUser;
using digitalShop.common.DTOClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]     ///important solution in routing (find in debug
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
            ViewBag.roles = new SelectList(_getRolesService.Execute().data, "Id", "Name");
            return View(_getuserlist.excute(new RequestGetUsersDTO
            {
                page = page,
                searchKey = searchkey,
            }));
        }
        //اصلا داخل سیستم روتینگ هیچ کدوم رو تشخیص نمیدهد فقط توسط لینک به این جا کشیده میشود وگرنه اصلا سیستم روتینگ کار نمیکند
        //[Route("Create")]
        [HttpGet]
        public IActionResult Create() {
           ViewBag.roles = new SelectList(_getRolesService.Execute().data, "Id", "Name"); //in html tag defined value tag : id and defined tage name : name
            return View();
        }
        //[Route("Create")]
        [HttpPost]
        public IActionResult Create(RequestRigesterServiceDTO requestRigester)
        {
            try
            {
                var temp = _rigesterUser.execute(requestRigester);
                ViewData["resultDataRigester"] = temp.data;
                ViewData["rigesterIsSuccess"] = temp.IsSuccess;
                ViewData["rigesterMessage"] = temp.message;
                if (temp.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.roles = new SelectList(_getRolesService.Execute().data, "Id", "Name");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }



    }
}
