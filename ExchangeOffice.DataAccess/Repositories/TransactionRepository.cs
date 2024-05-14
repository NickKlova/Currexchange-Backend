using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class TransactionRepository : BaseRepository, ITransactionRepository {
		private DataAccessContext _context;
		public TransactionRepository(DataAccessContext context) {
			_context = context;
		}

		public async Task<IEnumerable<Transaction>> GetTransactionsAsync() {
			return await Task.FromResult(_context.Transactions
				.Where(x=>x.IsActive == true)
				.Include(x=>x.Contact)
				.Include(x=>x.Rate)
				.AsNoTracking());
		}
		public async Task<Transaction> CreateTransactionAsync(Transaction entity) {
			SetDefaultValues(entity);
			await _context.Transactions.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Transaction> UpdateTransactionAsync(Transaction entity) {
			var oldEntity = await _context.Transactions.FindAsync(entity.Id);
			if(oldEntity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Transaction with such id didn't found");
			}
			SetDeleteDefaultValues(oldEntity);
			await _context.SaveChangesAsync();
			var modifiedEntity = await CreateTransactionAsync(entity);
			return modifiedEntity;
		}
		public async Task<Transaction> DeleteTransactionAsync(Guid id) {
			var entity = await _context.Transactions.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Transaction with such id didn't found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
