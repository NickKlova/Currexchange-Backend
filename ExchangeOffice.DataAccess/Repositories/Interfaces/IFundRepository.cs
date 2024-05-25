using ExchangeOffice.DataAccess.DAO;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IFundRepository {
		public Task<Fund> GetFundAsync(Guid id);
		public Task<Fund> GetFundByCurrencyIdAsync(Guid currencyId);
		public Task<IEnumerable<Fund>> GetFundsAsync();
		public Task<Fund> AddFundAsync(Fund entity);
		public Task<Fund> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount);
		public Task<Fund> UpdateFundAsync(Fund entity);
		public Task<Fund> DeleteFundAsync(Guid id);
		public Task<IEnumerable<Fund>> GetDeletedFundsAsync();

		public Task<Fund> ActivateDeletedFundAsync(Fund entity);
		}
}
