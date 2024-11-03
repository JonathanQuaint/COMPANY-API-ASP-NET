using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}
