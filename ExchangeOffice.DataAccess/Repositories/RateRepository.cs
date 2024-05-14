using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class RateRepository : BaseRepository, IRateRepository {
		private readonly DataAccessContext _context;
		public RateRepository(DataAccessContext context) {
			_context = context;
		}

		public async Task<IEnumerable<Rate>> GetRatesAsync() {
			return await Task.FromResult(_context.Rates
				.Include(x => x.TargetCurrency)
				.Include(x => x.BaseCurrency)
				.Where(x => x.IsActive == true)
				.AsNoTracking());
		}
		public async Task<Rate> GetRateByIdAsync(Guid id) {
			var entity = await _context.Rates.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such id not found");
			}
			return entity;
		}
		public async Task<Rate> GetRateAsync(Guid baseCurrencyId, Guid targetCurrencyId) {
			var entity = await _context.Rates.Where(x => x.BaseCurrencyId == baseCurrencyId
			&& x.TargetCurrencyId == targetCurrencyId
			&& x.IsActive == true).FirstOrDefaultAsync();

			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such base and target currencies id not found");
			}

			return entity;
		}
		public async Task<Rate> AddRateAsync(Rate entity) {
			SetDefaultValues(entity);
			var baseCurrency = await _context.Currencies.FindAsync(entity.BaseCurrencyId);
			if (baseCurrency == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Base currency with such id not found in database, so entity didn't created");
			}

			var targetCurrency = await _context.Currencies.FindAsync(entity.TargetCurrencyId);
			if (targetCurrency == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Target currency with such id not found in database, so entity didn't created");
			}

			entity.BaseCurrency = baseCurrency;
			entity.TargetCurrency = targetCurrency;

			await _context.Rates.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Rate> UpdateRateAsync(Rate entity) {
			var oldEntity = await _context.Rates.FindAsync(entity.Id);
			if (oldEntity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such id not found");
			}
			entity.Id = oldEntity.Id;
			entity.ModifiedOn = DateTime.UtcNow;
			_context.Rates.Remove(oldEntity);
			await _context.Rates.AddAsync(entity);
			return entity;
		}
		public async Task<Rate> DeleteRateAsync(Guid id) {
			var entity = await _context.Rates.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "A rate with such id was not found in the database");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
