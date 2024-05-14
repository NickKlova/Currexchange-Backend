using ExchangeOffice.Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeOffice.Common.Extensions {
	public static class CommonExtensions {
		public static void AddGlobalErrorHandling(this IServiceCollection services) {

		}

		public static void UseGlobalErrorHandling(this IApplicationBuilder app) {
			app.UseMiddleware<GlobalErrorHandlerMiddleware>();
		}
	}
}
