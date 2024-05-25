using ExchangeOffice.DataAccess.DAO;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IRateRepository {
		public Task<IEnumerable<Rate>> GetRatesByTargetCurrencyIdAsync(Guid targetCurrencyId);
		public Task<IEnumerable<Rate>> GetRatesByBaseCurrencyIdAsync(Guid baseCurrencyId);
		public Task<IEnumerable<Rate>> GetRatesAsync();
		public Task<Rate> GetRateAsync(Guid id);
		public Task<Rate> GetRateByCurrenciesAsync(Guid baseCurrencyId, Guid targetCurrencyId);
		public Task<Rate> AddRateAsync(Rate entity);
		public Task<Rate> UpdateRateAsync(Rate entity);
		public Task<Rate> DeleteRateAsync(Guid id);
		public Task<IEnumerable<Rate>> GetDeletedRates();
		public Task<Rate> ActivateDeletedRateAsync(Rate entity);
	}
}
