using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IFundRepository {
		public Task<Fund> GetFundByIdAsync(Guid id);
		public Task<Fund> GetFundAsync(Guid currencyId);
		public Task<IEnumerable<Fund>> GetFundsAsync();
		public Task<Fund> AddFundAsync(Fund entity);
		public Task<Fund> UpdateFundAsync(Guid currencyId, decimal amount);
		public Task<Fund> UpdateFundByIdAsync(Fund entity);
		public Task<Fund> DeleteFundAsync(Guid id);
	}
}
