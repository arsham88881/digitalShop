using digitalShop.domain.entites.common;

namespace digitalShop.domain.entites.users
{
    public class UserInRole :BaseOption
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual Role Role { get; set; }
        public long RoleID { get; set; }

    }
}
