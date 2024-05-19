using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class RateService : IRateService {
		private readonly IRateRepository _repo;
		private readonly IMapper _mapper;

		public RateService(IRateRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RateDto>> GetRatesByTargetCurrencyIdAsync(Guid targetCurrencyId) {
			var daos = await _repo.GetRatesByTargetCurrencyIdAsync(targetCurrencyId);
			var dtos = _mapper.Map<IEnumerable<RateDto>>(daos);
			return dtos;
		}
		public async Task<IEnumerable<RateDto>> GetRatesByBaseCurrencyIdAsync(Guid baseCurrencyId) {
			var daos = await _repo.GetRatesByBaseCurrencyIdAsync(baseCurrencyId);
			var dtos = _mapper.Map<IEnumerable<RateDto>>(daos);
			return dtos;
		}
		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			var daos = await _repo.GetRatesAsync();
			var dtos = _mapper.Map<IEnumerable<RateDto>>(daos);
			return dtos;
		}
		public async Task<RateDto> GetRateAsync(Guid id) {
			var dao = await _repo.GetRateAsync(id);
			var dto = _mapper.Map<RateDto>(dao);
			return dto;
		}
		public async Task<RateDto> GetRateByCurrenciesAsync(Guid baseCurrencyId, Guid targetCurrencyId) {
			var dao = await _repo.GetRateByCurrenciesAsync(baseCurrencyId, targetCurrencyId);
			var dto = _mapper.Map<RateDto>(dao);
			return dto;
		}
		public async Task<RateDto> AddRateAsync(InsertRateDto entity) {
			var dao = _mapper.Map<Rate>(entity);
			var daoResult = await _repo.AddRateAsync(dao);
			var dto = _mapper.Map<RateDto>(daoResult);
			return dto;
		}
		public async Task<RateDto> UpdateRateAsync(Guid id, InsertRateDto entity) {
			var dao = _mapper.Map<Rate>(entity);
			dao.Id = id;
			var daoResult = await _repo.UpdateRateAsync(dao);
			var dto = _mapper.Map<RateDto>(daoResult);
			return dto;
		}
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			var dao = await _repo.DeleteRateAsync(id);
			var dto = _mapper.Map<RateDto>(dao);
			return dto;
		}
	}
}
