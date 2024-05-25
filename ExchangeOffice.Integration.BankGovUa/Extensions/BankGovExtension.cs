using ExchangeOffice.Integration.BankGov.Managers;
using ExchangeOffice.Integration.BankGov.Managers.Interfaces;
using ExchangeOffice.Integration.BankGov.Services;
using ExchangeOffice.Integration.BankGovUa.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeOffice.Integration.BankGov.Extensions {
	public static class BankGovExtension {
		public static void AddBankGovLayer(this IServiceCollection services) {
			services.AddSingleton<IBankGovService, BankGovUaService>();
			services.AddSingleton<IBankGovManager, BankGovUaManager>();
		}
	}
}
