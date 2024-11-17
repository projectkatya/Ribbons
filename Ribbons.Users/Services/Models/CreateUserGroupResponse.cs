namespace Ribbons.Users.Services.Models
{
    public class CreateUserGroupResponse : UserManagerResponse<CreateUserGroupResponseCode>
    {
        public long UserGroupId { get; internal set; }
    }
}