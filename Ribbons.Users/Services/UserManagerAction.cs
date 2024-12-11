namespace Ribbons.Users.Services;

public enum UserManagerAction
{
    Undefined = 0,
    CreateUserScope = 1,
    EditUserScope = 2,
    CreateUserScopeAlias = 3,
    EditUserScopeAlias = 4,
    CreateUserType = 5,
    EditUserType = 6,
    CreateUserAttributeType = 7,
    CreateUserCredentialType = 8,
    CreateUserStatus = 9,
    CreateUserTokenType = 10
}