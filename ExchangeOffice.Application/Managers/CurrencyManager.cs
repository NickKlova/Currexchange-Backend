﻿using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class CurrencyManager : ICurrencyManager {
		private readonly ICurrencyService _service;
		public CurrencyManager(ICurrencyService service) {
			_service = service;
		}

		public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync() {
			return await _service.GetCurrenciesAsync();
		}
		public async Task<CurrencyDto> GetCurrencyAsync(Guid id) {
			return await _service.GetCurrencyAsync(id);
		}
		public async Task<CurrencyDto> AddCurrencyAsync(InsertCurrencyDto data) {
			return await _service.AddCurrencyAsync(data);
		}
		public async Task<CurrencyDto> UpdateCurrencyAsync(Guid id, InsertCurrencyDto entity) {
			return await _service.UpdateCurrencyAsync(id, entity);
		}
		public async Task<CurrencyDto> DeleteCurrencyAsync(Guid id) {
			return await _service.DeleteCurrencyAsync(id);
		}
	}
}
