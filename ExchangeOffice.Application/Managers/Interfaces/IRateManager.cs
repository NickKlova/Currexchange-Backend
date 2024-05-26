using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IRateManager {
		public Task<IEnumerable<RateDto>> GetRatesAsync();
		public Task<IEnumerable<RateDto>> GetDeletedRatesAsync();
		public Task<RateDto> GetRateAsync(Guid id);
		public Task<RateDto> GetRateByCurrencyAsync(Guid currencyId);
		public Task<RateDto> AddRateAsync(InsertRateDto entity);
		public Task<RateDto> UpdateRateAsync(Guid id, InsertRateDto entity);
		public Task<RateDto> DeleteRateAsync(Guid id);
		public Task<RateDto> ActivateDeletedRateAsync(Guid id, InsertRateDto entity);
	}
}
