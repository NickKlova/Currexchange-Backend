using ExchangeOffice.Application.DTO;
using ExchangeOffice.Integration.BankGov.Models;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface ICurrencyManager {
		public Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync();
		public Task<IEnumerable<BankGovCurrency>> GetBankGovCurrencies();
		public Task<CurrencyDto> GetCurrencyAsync(Guid id);
		public Task<CurrencyDto> AddCurrencyAsync(InsertCurrencyDto data);
		public Task<CurrencyDto> UpdateCurrencyAsync(Guid id, InsertCurrencyDto entity);
		public Task<CurrencyDto> DeleteCurrencyAsync(Guid id);
		}
	}
