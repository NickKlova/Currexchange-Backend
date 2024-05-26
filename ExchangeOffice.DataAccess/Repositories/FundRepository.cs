using AutoMapper;
using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Abstractions;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ExchangeOffice.DataAccess.Repositories {
	public class FundRepository : BaseRepository, IFundRepository {
		#region Fields: Private

		private readonly DataAccessContext _context;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors: Public

		public FundRepository(DataAccessContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<Fund>> GetDeletedFundsAsync() {
			return await Task.FromResult(_context.Funds
				.Include(x => x.Currency)
				.Where(x => x.IsActive == false)
				.AsNoTracking());
		}
		public async Task<IEnumerable<Fund>> GetFundsAsync() {
			return await Task.FromResult(_context.Funds
				.Include(x => x.Currency)
				.Where(x => x.IsActive == true)
				.AsNoTracking());
		}
		public async Task<Fund> GetFundAsync(Guid id) {
			var entity = await _context.Funds
				.Include(x => x.Currency)
				.Where(x=>x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			return entity;
		}
		public async Task<Fund> GetFundByCurrencyIdAsync(Guid currencyId) {
			var entity = await _context.Funds
				.Include(x => x.Currency)
				.Where(x => x.CurrencyId == currencyId && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such currency id not found");
			}
			return entity;
		}
		public async Task<Fund> AddFundAsync(Fund entity) {
			SetDefaultValues(entity);
			await _context.Funds.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Fund> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount) {
			var entity = await _context.Funds
				.Where(x => x.CurrencyId == currencyId && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such currency id not found in database, so entity didn't updated");
			}
			entity.ModifiedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Fund> UpdateFundAsync(Fund entity) {
			var oldEntity = await _context.Funds
				.Include(x=>x.Currency)
				.Where(x=>x.Id == entity.Id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return oldEntity;

		}
		public async Task<Fund> ActivateDeletedFundAsync(Fund entity) {
			var oldEntity = await _context.Funds
				.Where(x => x.Id == entity.Id && x.IsActive == false)
				.FirstOrDefaultAsync();
			if (oldEntity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			_mapper.Map(entity, oldEntity);
			await _context.SaveChangesAsync();
			return entity;
		}
		public async Task<Fund> DeleteFundAsync(Guid id) {
			var entity = await _context.Funds
				.Where(x=>x.Id == id && x.IsActive == true)
				.FirstOrDefaultAsync();
			if (entity == null) {
				throw new RecordNotFoundException(404, "DataAccess", "Fund with such id not found");
			}
			SetDeleteDefaultValues(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		#endregion
	}
}
