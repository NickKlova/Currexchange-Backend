using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface ITransactionManager {
		public Task<IEnumerable<TransactionDto>> GetTransactionsAsync();
		public Task<TransactionDto> CreateTransactionAsync(InsertTransactionDto transaction);
		public Task<TransactionDto> UpdateTransactionAsync(Guid id, InsertTransactionDto transaction);
		public Task<TransactionDto> DeleteTransactionAsync(Guid id);
	}
}
