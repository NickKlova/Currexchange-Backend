using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class RateManager : IRateManager {
		#region Fields: Private

		private readonly IRateService _service;

		#endregion

		#region Constructors: Public

		public RateManager(IRateService service) {
			_service = service;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			return await _service.GetRatesAsync();
		}
		public async Task<IEnumerable<RateDto>> GetDeletedRatesAsync() {
			return await _service.GetDeletedRatesAsync();
		}
		public async Task<RateDto> GetRateAsync(Guid id) {
			return await _service.GetRateAsync(id);
		}
		public async Task<RateDto> GetRateByCurrencyAsync(Guid currencyId) {
			return await _service.GetRateByCurrencyAsync(currencyId);
		}
		public async Task<RateDto> AddRateAsync(InsertRateDto entity) {
			return await _service.AddRateAsync(entity);
		}
		public async Task<RateDto> UpdateRateAsync(Guid id, InsertRateDto entity) {
			return await _service.UpdateRateAsync(id, entity);
		}
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			return await _service.DeleteRateAsync(id);
		}
		public async Task<RateDto> ActivateDeletedRateAsync(Guid id, InsertRateDto entity) {
			return await _service.ActivateDeletedRateAsync(id, entity);
		}

		#endregion
	}
}
