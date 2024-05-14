using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class FundService : IFundService {
		private readonly IFundRepository _repo;
		private readonly IMapper _mapper;

		public FundService(IFundRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<FundDto> GetFundByIdAsync(Guid id) {
			var dao = await _repo.GetFundByIdAsync(id);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
		public async Task<FundDto> GetFundAsync(Guid currencyId) {
			var dao = await _repo.GetFundAsync(currencyId);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			var daos = await _repo.GetFundsAsync();
			var dtos = _mapper.Map<IEnumerable<FundDto>>(daos);
			return dtos;
		}
		public async Task<FundDto> AddFundAsync(InsertFundDto entity) {
			var dao = _mapper.Map<Fund>(entity);
			var resultDao = await _repo.AddFundAsync(dao);
			var dto = _mapper.Map<FundDto>(resultDao);
			return dto;
		}
		public async Task<FundDto> UpdateFundAsync(Guid currencyId, decimal amount) {
			var dao = await _repo.UpdateFundAsync(currencyId, amount);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
		public async Task<FundDto> UpdateFundByIdAsync(Guid id, InsertFundDto entity) {
			var dao = _mapper.Map<Fund>(entity);
			dao.Id = id;
			var resultDao = await _repo.UpdateFundByIdAsync(dao);
			var dto = _mapper.Map<FundDto>(resultDao);
			return dto;
		}
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			var dao = await _repo.DeleteFundAsync(id);
			var dto = _mapper.Map<FundDto>(dao);
			return dto;
		}
	}
}
