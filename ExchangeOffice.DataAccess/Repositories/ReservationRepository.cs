using AutoMapper;
using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class ReservationRepository : BaseRepository, IReservationRepository {
		private readonly DataAccessContext _context;
		private readonly IMapper _mapper;
		public ReservationRepository(DataAccessContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Reservation>> GetReservationsAsync() {
			return await Task.FromResult(_context.Reservations
				.Include(x => x.Contact)
				.Include(x => x.Rate)
				.ThenInclude(r => r.Currency)
				.Where(x=>x.IsActive)
				.AsNoTracking());

		}
		public async Task<Reservation> GetReservationAsync(Guid id) {

			var entity = await _context.Reservations
				.Include(x => x.Contact)
				.Include(x => x.Rate)
				.ThenInclude(r => r.Currency)
				.Where(x => x.Id == id && x.IsActive == true)
				.AsNoTracking()
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Reservation with such id not found");
			}
			return entity;
		}
		public async Task<Reservation> AddReservationAsync(Reservation entity) {
			SetDefaultValues(entity);
			await _context.Reservations.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;

		}
		public async Task<Reservation> UpdateReservationAsync(Reservation entity) {
			var oldEntity = await _context.Reservations
				.Where(x => x.Id == entity.Id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataLayer", "Reservation with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Reservation> DeleteReservationAsync(Guid id) {
			var entity = await _context.Reservations
				.Where(x=>x.Id==id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Reservation with such id not found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
