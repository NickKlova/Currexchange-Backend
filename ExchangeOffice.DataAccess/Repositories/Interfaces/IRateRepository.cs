using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IRateRepository {
		public Task<IEnumerable<Rate>> GetRatesAsync();
		public Task<IEnumerable<Rate>> GetDeletedRatesAsync();
		public Task<Rate> GetRateAsync(Guid id);
		public Task<Rate> GetRateByCurrencyAsync(Guid currencyId);
		public Task<Rate> AddRateAsync(Rate entity);
		public Task<Rate> UpdateRateAsync(Rate entity);
		public Task<Rate> ActivateDeletedRateAsync(Rate entity);
		public Task<Rate> DeleteRateAsync(Guid id);
	}
}
