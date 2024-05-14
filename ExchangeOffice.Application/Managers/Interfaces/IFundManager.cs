using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IFundManager {
		public Task<FundDto> GetFundByIdAsync(Guid id);
		public Task<FundDto> GetFundAsync(Guid currencyId);
		public Task<IEnumerable<FundDto>> GetFundsAsync();
		public Task<FundDto> AddFundAsync(InsertFundDto entity);
		public Task<FundDto> UpdateFundAsync(Guid currencyId, decimal amount);
		public Task<FundDto> UpdateFundByIdAsync(Guid id, InsertFundDto entity);
		public Task<FundDto> DeleteFundAsync(Guid id);
	}
}
