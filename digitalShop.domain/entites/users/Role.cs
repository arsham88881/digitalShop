using digitalShop.domain.entites.common;

namespace digitalShop.domain.entites.users
{
    public class Role: BaseOption
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}
