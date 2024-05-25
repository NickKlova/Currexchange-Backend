using AutoMapper;
using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class TransactionRepository : BaseRepository, ITransactionRepository {
		private DataAccessContext _context;
		private IMapper _mapper;
		public TransactionRepository(DataAccessContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Transaction>> GetTransactionsAsync() {
			return await Task.FromResult(_context.Transactions
				.Where(x=>x.IsActive == true)
				.Include(x=>x.Contact)
				.Include(x=>x.Rate)
				.Include(x=>x.Rate.Currency)
				.AsNoTracking());
		}
		public async Task<Transaction> CreateTransactionAsync(Transaction entity) {
			SetDefaultValues(entity);
			await _context.Transactions.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Transaction> UpdateTransactionAsync(Transaction entity) {
			var oldEntity = await _context.Transactions
				.Where(x=>x.Id == entity.Id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if(oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Transaction with such id didn't found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return oldEntity;
		}
		public async Task<Transaction> DeleteTransactionAsync(Guid id) {
			var entity = await _context.Transactions
				.Where(x=>x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Transaction with such id didn't found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
