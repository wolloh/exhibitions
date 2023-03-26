using Duende.IdentityServer.Models;
using exhibition.Common.Security;

namespace exhibitions.Identity.Configuration.IS4
{
    public static class AppApiScopes
    {
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
            {
            new ApiScope(AppScopes.ExhibitionsView, "Access to exhibitions api - View exhibitions"),
            new ApiScope(AppScopes.ExhibitionsCreate, "Access to exhibitions api - Create Exhibitions")
            };
    }
}
