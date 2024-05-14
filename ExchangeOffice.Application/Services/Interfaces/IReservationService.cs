using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Services.Interfaces {
	public interface IReservationService {
		public Task<IEnumerable<ReservationDto>> GetReservationsAsync();
		public Task<ReservationDto> GetReservationAsync(Guid id);
		public Task<ReservationDto> AddReservationAsync(InsertReservationDto entity);
		public Task<ReservationDto> UpdateReservationAsync(Guid id, InsertReservationDto entity);
		public Task<ReservationDto> DeleteReservationAsync(Guid id);
	}
}
