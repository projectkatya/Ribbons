namespace Ribbons.Users
{
    public class UserTokenType
    {
        public long UserTokenTypeId { get; set; }
        public long UserDomainId { get; set; }
        public long UserTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}