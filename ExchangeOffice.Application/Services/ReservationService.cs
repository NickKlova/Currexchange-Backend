using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class ReservationService : IReservationService {
		private readonly IReservationRepository _repo;
		private readonly IMapper _mapper;
		public ReservationService(IReservationRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ReservationDto>> GetReservationsAsync() {
			var daos = await _repo.GetReservationsAsync();
			var dtos = _mapper.Map<IEnumerable<ReservationDto>>(daos);
			return dtos;
		}
		public async Task<ReservationDto> GetReservationAsync(Guid id) {
			var dao = await _repo.GetReservationAsync(id);
			var dto = _mapper.Map<ReservationDto>(dao);
			return dto;
		}
		public async Task<ReservationDto> AddReservationAsync(InsertReservationDto entity) {
			var dao = _mapper.Map<Reservation>(entity);
			var resultDao = await _repo.AddReservationAsync(dao);
			var dto = _mapper.Map<ReservationDto>(resultDao);
			return dto;
		}
		public async Task<ReservationDto> UpdateReservationAsync(Guid id, InsertReservationDto entity) {
			var dao = _mapper.Map<Reservation>(entity);
			dao.Id = id;
			var resultDao = await _repo.UpdateReservationAsync(dao);
			var dto = _mapper.Map<ReservationDto>(resultDao);
			return dto;

		}
		public async Task<ReservationDto> DeleteReservationAsync(Guid id) {
			var dao = await _repo.DeleteReservationAsync(id);
			var dto = _mapper.Map<ReservationDto>(dao);
			return dto;
		}
	}
}
