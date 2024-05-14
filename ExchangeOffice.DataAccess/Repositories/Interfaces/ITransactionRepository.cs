using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface ITransactionRepository {
		public Task<IEnumerable<Transaction>> GetTransactionsAsync();
		public Task<Transaction> CreateTransactionAsync(Transaction entity);
		public Task<Transaction> UpdateTransactionAsync(Transaction entity);
		public Task<Transaction> DeleteTransactionAsync(Guid id);
	}
}
