namespace digitalShop.application.Services.Users.Commands.RegesterUser
{
    public class RequestRigesterServiceDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

        public List<RolesInRigesterUserDTO> roles { get; set; }
    }
}
