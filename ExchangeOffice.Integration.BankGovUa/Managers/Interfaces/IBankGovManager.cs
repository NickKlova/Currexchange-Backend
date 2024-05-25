using ExchangeOffice.Integration.BankGov.Models;

namespace ExchangeOffice.Integration.BankGov.Managers.Interfaces
{
    public interface IBankGovManager {
		public Task<IEnumerable<BankGovCurrency>> GetCurrenciesAsync();
		public Task<IEnumerable<BankGovRate>> GetRatesAsync();
	}
}
