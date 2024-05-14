using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IRateRepository {
		public Task<IEnumerable<Rate>> GetRatesAsync();
		public Task<Rate> GetRateByIdAsync(Guid id);
		public Task<Rate> GetRateAsync(Guid baseCurrencyId, Guid targetCurrencyId);
		public Task<Rate> AddRateAsync(Rate entity);
		public Task<Rate> UpdateRateAsync(Rate entity);
		public Task<Rate> DeleteRateAsync(Guid id);
	}
}
