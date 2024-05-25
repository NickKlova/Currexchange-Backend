﻿using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class RateManager : IRateManager {
		private readonly IRateService _service;
		public RateManager(IRateService service) {
			_service = service;
		}

		public async Task<IEnumerable<RateDto>> GetRatesByTargetCurrencyIdAsync(Guid targetCurrencyId) {
			return await _service.GetRatesByTargetCurrencyIdAsync(targetCurrencyId);
		}
		public async Task<IEnumerable<RateDto>> GetRatesByBaseCurrencyIdAsync(Guid baseCurrencyId) {
			return await _service.GetRatesByBaseCurrencyIdAsync(baseCurrencyId);
		}
		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			return await _service.GetRatesAsync();
		}
		public async Task<RateDto> GetRateAsync(Guid id) {
			return await _service.GetRateAsync(id);
		}
		public async Task<RateDto> GetRateByCurrenciesAsync(Guid baseCurrencyId, Guid targetCurrencyId) {
			return await _service.GetRateByCurrenciesAsync(baseCurrencyId, targetCurrencyId);
		}
		public async Task<RateDto> AddRateAsync(InsertRateDto entity) {
			return await _service.AddRateAsync(entity);
		}
		public async Task<RateDto> UpdateRateAsync(Guid id, InsertRateDto entity) {
			return await _service.UpdateRateAsync(id, entity);
		}
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			return await _service.DeleteRateAsync(id);
		}
		public async Task<IEnumerable<RateDto>> GetDeletedRates() {
			return await _service.GetDeletedRates();
		}
		public async Task<RateDto> ActivateDeletedRateAsync(Guid id, InsertRateDto entity) {
			return await _service.ActivateDeletedRateAsync(id, entity);
		}
	}
}
