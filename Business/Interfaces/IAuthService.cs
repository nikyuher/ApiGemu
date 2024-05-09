using Gemu.Models;
using System.Security.Claims;
namespace Gemu.Data;
public interface IAuthService
{
    //Auth

    string GenerateJwtToken(Usuario usuario);
    public bool HasAccessToResource(ClaimsPrincipal user, int resourceOwnerId);
}
