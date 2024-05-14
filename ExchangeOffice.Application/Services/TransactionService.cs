using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class TransactionService : ITransactionService {
		private readonly ITransactionRepository _repo;
		private readonly IMapper _mapper;
		public TransactionService(ITransactionRepository repo, IMapper mapper) {
			_mapper = mapper;
			_repo = repo;
		}

		public async Task<TransactionDto> CreateTransactionAsync(InsertTransactionDto transaction) {
			var dao = _mapper.Map<Transaction>(transaction);
			var daoResult = await _repo.CreateTransactionAsync(dao);
			var dto = _mapper.Map<TransactionDto>(daoResult);
			return dto;
		}

		public async Task<TransactionDto> DeleteTransactionAsync(Guid id) {
			var dao = await _repo.DeleteTransactionAsync(id);
			var dto = _mapper.Map<TransactionDto>(dao);
			return dto;
		}

		public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync() {
			var daos = await _repo.GetTransactionsAsync();
			var dtos = _mapper.Map<IEnumerable<TransactionDto>>(daos);
			return dtos;
		}

		public async Task<TransactionDto> UpdateTransactionAsync(Guid id, InsertTransactionDto transaction) {
			var dao = _mapper.Map<Transaction>(transaction);
			dao.Id = id;
			var resultDao = await _repo.UpdateTransactionAsync(dao);
			var dto = _mapper.Map<TransactionDto>(resultDao);
			return dto;
		}
	}
}
