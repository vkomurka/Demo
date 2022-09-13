using Microsoft.AspNetCore.Authorization;

namespace Demo.WebServer.Model.Roles
{
    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
