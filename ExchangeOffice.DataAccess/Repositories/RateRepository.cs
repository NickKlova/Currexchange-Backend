using AutoMapper;
using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class RateRepository : BaseRepository, IRateRepository {
		#region Fields: Private

		private readonly DataAccessContext _context;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors: Public

		public RateRepository(DataAccessContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<Rate>> GetRatesAsync() {
			return await Task.FromResult(_context.Rates
				.Include(x => x.Currency)
				.Where(x => x.IsActive == true)
				.AsNoTracking());
		}
		public async Task<IEnumerable<Rate>> GetDeletedRatesAsync() {
			return await Task.FromResult(_context.Rates
				.Include(x => x.Currency)
				.Where(x => x.IsActive == false)
				.AsNoTracking());
		}
		public async Task<Rate> GetRateAsync(Guid id) {
			var entity = await _context.Rates
				.Include(x => x.Currency)
				.Where(x => x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such id not found");
			}
			return entity;
		}
		public async Task<Rate> GetRateByCurrencyAsync(Guid currencyId) {
			var entity = await _context.Rates
				.Include(x=>x.Currency).Where(x => x.CurrencyId == currencyId
			&& x.IsActive == true).FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such base and target currencies id not found");
			}
			return entity;
		}
		public async Task<Rate> AddRateAsync(Rate entity) {
			SetDefaultValues(entity);
			await _context.Rates.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Rate> UpdateRateAsync(Rate entity) {
			var oldEntity = await _context.Rates
				.Include(x=>x.Currency)
				.Where(x=>x.Id == entity.Id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Rate> ActivateDeletedRateAsync(Rate entity) {
			var oldEntity = await _context.Rates
				.Include(x => x.Currency)
				.Where(x => x.Id == entity.Id && x.IsActive == false)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Rate with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Rate> DeleteRateAsync(Guid id) {
			var entity = await _context.Rates
				.Include(x => x.Currency)
				.Where(x => x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "A rate with such id was not found in the database");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		#endregion
	}
}
