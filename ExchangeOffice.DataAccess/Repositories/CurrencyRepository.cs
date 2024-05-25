using AutoMapper;
using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class CurrencyRepository : BaseRepository, ICurrencyRepository {
		#region Fields: Private

		private readonly DataAccessContext _context;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors: Public

		public CurrencyRepository(DataAccessContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<Currency>> GetCurrenciesAsync() {
			return await Task.FromResult(_context.Currencies
				.Where(x=>x.IsActive==true)
				.AsNoTracking());
		}
		public async Task<IEnumerable<Currency>> GetDeletedCurrenciesAsync() {
			return await Task.FromResult(_context.Currencies
				.Where(x => x.IsActive == false)
				.AsNoTracking());
		}
		public async Task<Currency> GetCurrencyAsync(Guid id) {
			var entity = await _context.Currencies
				.Where(x=>x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}
			return entity;
		}
		public async Task<Currency> AddCurrencyAsync(Currency entity) {
			SetDefaultValues(entity);
			await _context.Currencies.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Currency> UpdateCurrencyAsync(Currency entity) {
			var oldEntity = await _context.Currencies
				.Where(x=>x.Id == entity.Id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Currency> ActivateCurrencyAsync(Currency entity) {
			var oldEntity = await _context.Currencies
				.Where(x => x.Id == entity.Id)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Currency> DeleteCurrencyAsync(Guid id) {
			var entity = await _context.Currencies
				.Where(x=>x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Currency with such id not found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		#endregion
	}
}
