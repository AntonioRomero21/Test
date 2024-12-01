using Microsoft.AspNetCore.Identity;

public class AuthorizationService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthorizationService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    public async Task<bool> AuthorizeAsync(string role)
    {
        var user = _contextAccessor.HttpContext.User;
        return user.IsInRole(role); 
    }
}