using ExchangeOffice.Integration.BankGov.Services.Abstractions;
using ExchangeOffice.Integration.BankGovUa.Services.Interfaces;

namespace ExchangeOffice.Integration.BankGov.Services {
	public class BankGovUaService : BaseService, IBankGovService {
		private readonly string _bankGovUaHost;
		public BankGovUaService() {
			_bankGovUaHost = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
		}

		public async Task<string> GetRatesAsync() {
			return await GetAsync(_bankGovUaHost);
		}
	}
}
