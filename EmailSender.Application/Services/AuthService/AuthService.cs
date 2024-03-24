using EmailSender.Domain.Entites.Models.AuthModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<string> GenerateToken(User user)
        {
            if(user == null)
            {
                return "User not found";
            }
            else if(user.Id != Guid.NewGuid())
            {
                return "User not found";
            }

            if(UserExitst(user)) 
            {
                //1-usul
                /*var service = _configuration.GetSection("JWT");
                var secretKey = service["Secret"];*/

                //2-usul

                //var key = _configuration["JWT: Secret"];

                List<Claim> claims = new List<Claim>()
                {

                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("UserName",user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("CreateDate",DateTime.UtcNow.ToString())
                };

                return await GenerateToken(claims);

            }

            else
            {
                return "User Un Authotihe 401";
            }

         


            

          
        }

        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
           
            var exDate = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public bool UserExitst(User user)
        {

            var login = "admin";
            var pasword = "1111";


            if(user.Login == login && user.Password == pasword) 
            {
                return true;

            }

            return false;
        }

    }

}
