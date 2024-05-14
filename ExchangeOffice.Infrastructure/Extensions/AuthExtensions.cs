using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Infrastructure.Extensions {
	public static class AuthExtensions {
		public static void AddJwtAuth(this IServiceCollection services) {
			services.AddAuthentication().AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					ValidateAudience = false,
					ValidateIssuer = false,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRETSECRET"))
				};
			});
		}
	}
}
