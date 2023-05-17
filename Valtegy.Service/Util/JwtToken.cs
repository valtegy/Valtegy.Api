using Valtegy.Domain.Constants;
using Valtegy.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Valtegy.Service.Util
{
    public static class JwtToken
    {
        public static UserClaims ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenResult = handler.ReadJwtToken(token);

            return new UserClaims
            {
                AppId = tokenResult.Claims.Where(c => c.Type == TypesClaim.AppId).Select(c => c.Value).FirstOrDefault(),
                UserId = tokenResult.Claims.Where(c => c.Type == TypesClaim.UserId).Select(c => c.Value).FirstOrDefault(),
                Roles = tokenResult.Claims.Where(c => c.Type == TypesClaim.Roles).Select(c => c.Value).FirstOrDefault()
            };
        }
    }
}
