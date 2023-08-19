using digitalShop.application.Services.Users.Commands.RegesterUser;
using digitalShop.application.Services.Users.Queries.getRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace endpoint.site.Controllers
{
    [Route("/User/[action]")]
    public class UserController : Controller
    {
        private readonly IRigesterUserService _rigesterUser;
        private readonly IgetRolesService _getRolesService;
        public UserController(IRigesterUserService rigesterUserService, IgetRolesService getRolesService) { 
            _rigesterUser = rigesterUserService;
            _getRolesService = getRolesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Register(RequestRigesterServiceDTO requestRigester)
        {
            requestRigester.roles = new List<RolesInRigesterUserDTO>()
                {
                     new RolesInRigesterUserDTO { ID = 3},
                };
            try
            {
                var temp = _rigesterUser.execute(requestRigester);
                ViewData["resultDataRigester"] = temp.data;
                ViewData["rigesterIsSuccess"] = temp.IsSuccess;
                ViewData["rigesterMessage"] = temp.message;
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
