using System;

namespace Ribbons.Users
{
    public class UserToken
    {
        public byte[] UserTokenId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long UserId { get; set; }
    }
}