using digitalShop.application.Services.Users.Commands.Change_status;
using digitalShop.application.Services.Users.Commands.RegesterUser;
using digitalShop.application.Services.Users.Commands.RemoveUser;
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
        private readonly IRemoveUserService _removeUser;
        private readonly IChangeStatusUserService _changeStatusUser;
        public AccountController(Igetuserlistservice getuserlist,
                               IRigesterUserService rigesterUser,
                               IgetRolesService getRolesService,
                               IRemoveUserService removeUserService,
                               IChangeStatusUserService changeStatusUser)
        {
            _getuserlist = getuserlist;
            _rigesterUser = rigesterUser;
            _getRolesService = getRolesService;
            _removeUser = removeUserService;
            _changeStatusUser = changeStatusUser;
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
        [HttpGet]
        public IActionResult Create() {
           ViewBag.roles = new SelectList(_getRolesService.Execute().data, "Id", "Name"); //in html tag defined value tag : id and defined tage name : name
            return View();
        }
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
        //[HttpPost] true way for post method and ajax in client side
        public IActionResult Remove(long UserId)
        {
            try
            {
                var temmmp = _removeUser.execute(UserId);
                ViewBag.RemoveResult = temmmp.message;
                ViewBag.RemoveSuccess = temmmp.IsSuccess;
                if(temmmp.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        public IActionResult ChangeStatus(long UserId)
        {
            try
            {
                var temmmp = _changeStatusUser.execute(UserId);
                ViewBag.ChangeResult = temmmp.message;
                ViewBag.ChangeSuccess = temmmp.IsSuccess;
                if (temmmp.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
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
