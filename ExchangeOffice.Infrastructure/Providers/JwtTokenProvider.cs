using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ExchangeOffice.Infrastructure.Providers {
	public static class JwtTokenProvider {
		public static string GenerateToken(string username, string role) {
			List<Claim> claims = new List<Claim> {
				new Claim(ClaimTypes.Name, username),
				new Claim(ClaimTypes.Role, "Owner"),
				new Claim(ClaimTypes.Role, "Manager"),
				new Claim(ClaimTypes.Role, "Cashier"),
				new Claim(ClaimTypes.Role, "User"),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				"SECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRET"));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds
				);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

		public static string HashPassword(string password) {
			return BCrypt.Net.BCrypt.HashPassword(password);
		}

		public static bool VerifyPassword(string password, string hashedPassword) {
			return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
		}
	}
}
