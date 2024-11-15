using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ribbons.Users.Services.Models
{
    public enum CreateUserTokenTypeResponseCode
    {
        Ok = 0,
        CodeInUse = 1,
        NameInUse = 2,
        InvalidRequest = 3,
        Error = 4,
        UserTypeNotFound = 5
    }
}
