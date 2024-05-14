using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IReservationRepository {
		public Task<IEnumerable<Reservation>> GetReservationsAsync();
		public Task<Reservation> GetReservationAsync(Guid id);
		public Task<Reservation> AddReservationAsync(Reservation entity);
		public Task<Reservation> UpdateReservationAsync(Reservation entity);
		public Task<Reservation> DeleteReservationAsync(Guid id);
	}
}
