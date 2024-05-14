using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class ReservationRepository : BaseRepository, IReservationRepository {
		private readonly DataAccessContext _context;
		private readonly IRateRepository _rateRepo;
		private readonly IContactRepository _contactRepo;
		public ReservationRepository(DataAccessContext context, IRateRepository rateRepo, IContactRepository contactRepo) {
			_context = context;
			_rateRepo = rateRepo;
			_contactRepo = contactRepo;
		}

		public async Task<IEnumerable<Reservation>> GetReservationsAsync() {
			return await Task.FromResult(_context.Reservations
				.Where(x => x.IsActive == true)
				.Include(x=>x.Contact)
				.Include(x=>x.Rate)
				.AsNoTracking());

		}
		public async Task<Reservation> GetReservationAsync(Guid id) {
			var entity = await _context.Reservations.Include(x=>x.Contact).Include(x=>x.Rate).Where(x=>x.Id == id).AsNoTracking().FirstOrDefaultAsync();
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Reservation with such id not found");
			}
			return entity;
		}
		public async Task<Reservation> AddReservationAsync(Reservation entity) {
			entity.Rate = await _rateRepo.GetRateByIdAsync(entity.RateId);
			entity.Contact = await _contactRepo.GetContactAsync(entity.ContactId);
			SetDefaultValues(entity);
			await _context.Reservations.AddAsync(entity);
			return entity;

		}
		public async Task<Reservation> UpdateReservationAsync(Reservation entity) {
			var oldEntity = await _context.Reservations.FindAsync(entity.Id);
			if (oldEntity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataLayer", "Reservation with such id not found");
			}
			entity.Id = oldEntity.Id;
			entity.ModifiedOn = DateTime.UtcNow;
			entity.Rate = await _rateRepo.GetRateByIdAsync(entity.RateId);
			entity.Contact = await _contactRepo.GetContactAsync(entity.ContactId);
			_context.Reservations.Remove(oldEntity);
			await _context.Reservations.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Reservation> DeleteReservationAsync(Guid id) {
			var entity = await _context.Reservations.FindAsync(id);
			if (entity == null || entity.IsActive == false) {
				throw new RecordNotFoundException(404, "DataAccess", "Reservation with such id not found");
			}
			entity.ModifiedOn = DateTime.UtcNow;
			entity.IsActive = false;
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
