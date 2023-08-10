namespace digitalShop.domain.entites.users
{
    public class UserInRole
    {
        public  long  ID { get; set; }

        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual Role Role { get; set; }
        public long RoleID { get; set; }

    }
}
