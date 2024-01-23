using System.Security.Claims;

namespace TaskManagement.API.AuthConfig
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var val = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(val, out int res))
            {
                return res;
            }
            return null;
        }
    }
}
