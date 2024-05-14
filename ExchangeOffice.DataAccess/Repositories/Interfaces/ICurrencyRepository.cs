using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface ICurrencyRepository {
		public Task<IEnumerable<Currency>> GetCurrenciesAsync();
		public Task<Currency> GetCurrencyAsync(Guid id);
		public Task<Currency> AddCurrencyAsync(Currency entity);
		public Task<Currency> UpdateCurrencyAsync(Currency entity);
		public Task<Currency> DeleteCurrencyAsync(Guid id);
	}
}
