namespace Ribbons.Users
{
    public class UserAttributeType
    {
        public long UserAttributeTypeId { get; set; }
        public long UserTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ValueType { get; set; }
    }
}