using ExchangeOffice.Application.DTO;
namespace ExchangeOffice.Application.Services.Interfaces {
	public interface ITransactionService {
		public Task<IEnumerable<TransactionDto>> GetTransactionsAsync();
		public Task<TransactionDto> CreateTransactionAsync(InsertTransactionDto transaction);
		public Task<TransactionDto> UpdateTransactionAsync(Guid id, InsertTransactionDto transaction);
		public Task<TransactionDto> DeleteTransactionAsync(Guid id);
	}
}
