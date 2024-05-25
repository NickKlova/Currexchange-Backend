using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IFundManager {
		public Task<FundDto> GetFundAsync(Guid id);
		public Task<FundDto> GetFundByCurrencyIdAsync(Guid currencyId);
		public Task<IEnumerable<FundDto>> GetFundsAsync();
		public Task<FundDto> AddFundAsync(InsertFundDto entity);
		public Task<FundDto> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount);
		public Task<FundDto> UpdateFundAsync(Guid id, InsertFundDto entity);
		public Task<FundDto> DeleteFundAsync(Guid id);
		public Task<IEnumerable<FundDto>> GetDeletedFundsAsync();
		public Task<FundDto> ActivateDeletedFundAsync(Guid id, InsertFundDto entity);
	}
}
