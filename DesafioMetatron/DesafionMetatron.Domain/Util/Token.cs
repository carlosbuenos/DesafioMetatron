using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafionMetatron.Domain.Util
{
	public class Token
	{
		public static string GenerateToken(Login login)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("63dd8125b8ab48658bc4cd968d179f8a"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
			var expiration = DateTime.UtcNow.AddHours(1);
			var claims = new[]
		   {
				new Claim(JwtRegisteredClaimNames.UniqueName, login.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			JwtSecurityToken token = new JwtSecurityToken(
			  issuer: null,
			  audience: null,
			  claims: claims,
			  expires: expiration,
			  signingCredentials: creds);
			return tokenHandler.WriteToken(token);
		}
	}
}
