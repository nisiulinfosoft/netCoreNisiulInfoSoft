using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Util
{
    public class Token
    {
        public static string Generar(string login, int codigo)
        {
            var claims = new[]
                           {
                new Claim("codigo", codigo.ToString()),
                new Claim("login", login)
            };

            //crear sigingcredencial
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PalabraSecreta123"));
            var sec = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "www.nisiulinfosoft.com",
                audience: "www.nisiulinfosoft.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: sec
                );

            string texto = new JwtSecurityTokenHandler().WriteToken(token);

            return texto;
        }
    }
}
