using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IReservationManager {
		public Task<ReservationDto> GetReservationAsync(Guid id);
		public Task<IEnumerable<ReservationDto>> GetReservationsAsync();
		public Task<ReservationDto> AddReservationAsync(InsertReservationDto reservation);
		public Task<ReservationDto> UpdateReservationAsync(Guid id, InsertReservationDto reservation);
		public Task<ReservationDto> DeleteReservationAsync(Guid id);
	}
}
