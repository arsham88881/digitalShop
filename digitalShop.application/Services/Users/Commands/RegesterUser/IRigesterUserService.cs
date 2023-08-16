using digitalShop.common.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalShop.application.Services.Users.Commands.RegesterUser
{
    public interface IRigesterUserService
    {
        ResultDTO<ResultRigesterUserDTO> execute(RequestRigesterServiceDTO request);
    }
}
