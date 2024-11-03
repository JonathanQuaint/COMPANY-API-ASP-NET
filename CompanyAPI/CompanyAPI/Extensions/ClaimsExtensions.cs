using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace CompanyAPI.Extensions
{
    public static class ClaimsExtensions
    {
        private const string GivenNameClaimType = "https://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";

        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals(GivenNameClaimType)).Value;
           
        }
    }
}
