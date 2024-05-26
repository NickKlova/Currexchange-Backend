using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class RateService : IRateService {
		#region Fields: Private

		private readonly IRateRepository _repo;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors: Public

		public RateService(IRateRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			var daos = await _repo.GetRatesAsync();
			var dtos = _mapper.Map<IEnumerable<RateDto>>(daos);
			return dtos;
		}
		public async Task<IEnumerable<RateDto>> GetDeletedRatesAsync() {
			var daos = await _repo.GetDeletedRatesAsync();
			var dtos = _mapper.Map<IEnumerable<RateDto>>(daos);
			return dtos;
		}
		public async Task<RateDto> GetRateAsync(Guid id) {
			var dao = await _repo.GetRateAsync(id);
			var dto = _mapper.Map<RateDto>(dao);
			return dto;
		}
		public async Task<RateDto> GetRateByCurrencyAsync(Guid currencyId) {
			var dao = await _repo.GetRateByCurrencyAsync(currencyId);
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
		public async Task<RateDto> ActivateDeletedRateAsync(Guid id, InsertRateDto entity) {
			var dao = _mapper.Map<Rate>(entity);
			dao.Id = id;
			var daoResult = await _repo.ActivateDeletedRateAsync(dao);
			var dto = _mapper.Map<RateDto>(daoResult);
			return dto;
		}
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			var dao = await _repo.DeleteRateAsync(id);
			var dto = _mapper.Map<RateDto>(dao);
			return dto;
		}

		#endregion
	}
}
