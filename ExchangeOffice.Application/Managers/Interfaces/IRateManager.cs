using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IRateManager {
		public Task<IEnumerable<RateDto>> GetRatesByTargetCurrencyIdAsync(Guid targetCurrencyId);
		public Task<IEnumerable<RateDto>> GetRatesByBaseCurrencyIdAsync(Guid baseCurrencyId);
		public Task<IEnumerable<RateDto>> GetRatesAsync();
		public Task<RateDto> GetRateAsync(Guid id);
		public Task<RateDto> GetRateByCurrenciesAsync(Guid baseCurrencyId, Guid targetCurrencyId);
		public Task<RateDto> AddRateAsync(InsertRateDto entity);
		public Task<RateDto> UpdateRateAsync(Guid id, InsertRateDto entity);
		public Task<RateDto> DeleteRateAsync(Guid id);
	}
}
