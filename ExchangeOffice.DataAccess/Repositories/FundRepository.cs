using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ExchangeOffice.DataAccess.Repositories {
	public class FundRepository : BaseRepository, IFundRepository {
		private readonly DataAccessContext _context;
		public FundRepository(DataAccessContext context) {
			_context = context;
		}

		public async Task<Fund> GetFundByIdAsync(Guid id) {
			var entity = await _context.Funds.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			return entity;
		}
		public async Task<Fund> GetFundAsync(Guid currencyId) {
			var entity = await _context.Funds.Include(x => x.Currency).Where(x => x.CurrencyId == currencyId && x.IsActive == true).FirstOrDefaultAsync();
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such currency id not found");
			}
			return entity;
		}
		public async Task<IEnumerable<Fund>> GetFundsAsync() {
			return await Task.FromResult(_context.Funds
				.Include(x => x.Currency)
				.Where(x => x.IsActive == true)
				.AsNoTracking());
		}
		public async Task<Fund> AddFundAsync(Fund entity) {
			SetDefaultValues(entity);
			var currency = await _context.Currencies.FindAsync(entity.CurrencyId);
			if (currency == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found in database, so entity didn't created");
			}
			entity.Currency = currency;
			await _context.Funds.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Fund> UpdateFundAsync(Guid currencyId, decimal amount) {
			var entity = await _context.Funds.Where(x => x.CurrencyId == currencyId && x.IsActive == true).FirstOrDefaultAsync();
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such currency id not found in database, so entity didn't updated");
			}
			entity.ModifiedOn = DateTime.UtcNow;
			entity.Amount = entity.Amount + amount;
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Fund> UpdateFundByIdAsync(Fund entity) {
			var oldEntity = await _context.Funds.FindAsync(entity.Id);
			if (oldEntity == null || oldEntity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			entity.ModifiedOn = DateTime.UtcNow;
			entity.Id = oldEntity.Id;
			entity.IsActive = true;
			_context.Funds.Remove(oldEntity);
			await _context.Funds.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;

		}
		public async Task<Fund> DeleteFundAsync(Guid id) {
			var entity = await _context.Funds.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
