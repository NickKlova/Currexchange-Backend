using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class CurrencyRepository : BaseRepository, ICurrencyRepository {
		private readonly DataAccessContext _context;
		public CurrencyRepository(DataAccessContext context) {
			_context = context;
		}

		public async Task<IEnumerable<Currency>> GetCurrenciesAsync() {
			return await Task.FromResult(_context.Currencies.Where(x=>x.IsActive==true).AsNoTracking());
		}
		public async Task<Currency> GetCurrencyAsync(Guid id) {
			var entity = await _context.Currencies.Where(x=>x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}

			return entity;
		}
		public async Task<Currency> AddCurrencyAsync(Currency entity) {
			SetDefaultValues(entity);
			await _context.Currencies.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Currency> UpdateCurrencyAsync(Currency entity) {
			var oldEntity = await _context.Currencies.FindAsync(entity.Id);
			if (oldEntity == null || oldEntity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}
			entity.ModifiedOn = DateTime.UtcNow;
			entity.Id = oldEntity.Id;
			entity.IsActive = true;
			_context.Currencies.Remove(oldEntity);
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Currency> DeleteCurrencyAsync(Guid id) {
			var entity = await _context.Currencies.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
