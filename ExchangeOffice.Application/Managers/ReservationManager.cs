using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class ReservationManager : IReservationManager {
		private readonly IReservationService _service;
		public ReservationManager(IReservationService service) {
			_service = service;
		}

		public async Task<ReservationDto> AddReservationAsync(InsertReservationDto reservation) {
			return await _service.AddReservationAsync(reservation);
		}

		public async Task<ReservationDto> DeleteReservationAsync(Guid id) {
			return await _service.DeleteReservationAsync(id);
		}

		public async Task<IEnumerable<ReservationDto>> GetReservationsAsync() {
			return await _service.GetReservationsAsync();
		}

		public async Task<ReservationDto> UpdateReservationAsync(Guid id, InsertReservationDto reservation) {
			return await _service.UpdateReservationAsync(id, reservation);
		}

		public async Task<ReservationDto> GetReservationAsync(Guid id) {
			return await _service.GetReservationAsync(id);
		}
	}
}
