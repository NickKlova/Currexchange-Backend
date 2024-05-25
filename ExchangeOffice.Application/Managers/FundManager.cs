using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class FundManager : IFundManager {
		private readonly IFundService _service;
		public FundManager(IFundService service) {
			_service = service;
		}
		public async Task<FundDto> GetFundAsync(Guid id) {
			return await _service.GetFundAsync(id);
		}
		public async Task<FundDto> GetFundByCurrencyIdAsync(Guid currencyId) {
			return await _service.GetFundByCurrencyIdAsync(currencyId);
		}
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			return await _service.GetFundsAsync();
		}
		public async Task<FundDto> AddFundAsync(InsertFundDto entity) {
			return await _service.AddFundAsync(entity);
		}
		public async Task<FundDto> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount) {
			return await _service.UpdateFundByCurrencyIdAsync(currencyId, amount);
		}
		public async Task<FundDto> UpdateFundAsync(Guid id, InsertFundDto entity) {
			return await _service.UpdateFundAsync(id, entity);
		}
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			return await _service.DeleteFundAsync(id);
		}
		public async Task<IEnumerable<FundDto>> GetDeletedFundsAsync() {
			return await _service.GetDeletedFundsAsync();
		}

		public async Task<FundDto> ActivateDeletedFundAsync(Guid id, InsertFundDto entity) {
			return await _service.ActivateDeletedFundAsync(id, entity);
		}
	}
}
