using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class FundManager : IFundManager {
		private readonly IFundService _service;
		public FundManager(IFundService service) {
			_service = service;
		}
		public async Task<FundDto> GetFundByIdAsync(Guid id) {
			return await _service.GetFundByIdAsync(id);
		}
		public async Task<FundDto> GetFundAsync(Guid currencyId) {
			return await _service.GetFundAsync(currencyId);
		}
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			return await _service.GetFundsAsync();
		}
		public async Task<FundDto> AddFundAsync(InsertFundDto entity) {
			return await _service.AddFundAsync(entity);
		}
		public async Task<FundDto> UpdateFundAsync(Guid currencyId, decimal amount) {
			return await _service.UpdateFundAsync(currencyId, amount);
		}
		public async Task<FundDto> UpdateFundByIdAsync(Guid id, InsertFundDto entity) {
			return await _service.UpdateFundByIdAsync(id, entity);
		}
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			return await _service.DeleteFundAsync(id);
		}
	}
}
