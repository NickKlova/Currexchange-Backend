﻿using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IRateManager {
		public Task<IEnumerable<RateDto>> GetRatesAsync();
		public Task<RateDto> GetRateByIdAsync(Guid id);
		public Task<RateDto> GetRateAsync(Guid baseCurrencyId, Guid targetCurrencyId);
		public Task<RateDto> AddRateAsync(InsertRateDto entity);
		public Task<RateDto> UpdateRateAsync(Guid id, InsertRateDto entity);
		public Task<RateDto> DeleteRateAsync(Guid id);
	}
}
