using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/rate")]
	[ApiController]
	public class RateController : ControllerBase {
		private readonly IRateManager _manager;
		public RateController(IRateManager manager) {
			_manager = manager;
		}

		[HttpGet("getall/bytargetcurrency/{targetCurrencyId}")]
		public async Task<IEnumerable<RateDto>> GetRatesByTargetCurrencyIdAsync(Guid targetCurrencyId) {
			return await _manager.GetRatesByTargetCurrencyIdAsync(targetCurrencyId);
		}

		[HttpGet("getall/bybasecurrency/{baseCurrencyId}")]
		public async Task<IEnumerable<RateDto>> GetRatesByBaseCurrencyIdAsync(Guid baseCurrencyId) {
			return await _manager.GetRatesByBaseCurrencyIdAsync(baseCurrencyId);
		}

		[HttpGet("getall")]
		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			return await _manager.GetRatesAsync();
		}

		[HttpGet("get/bycurrencies")]
		public async Task<RateDto> GetRateByCurrenciesAsync(Guid baseCurrency, Guid targetCurrency) {
			return await _manager.GetRateByCurrenciesAsync(baseCurrency, targetCurrency);
		}

		[HttpGet("get")]
		public async Task<RateDto> GetRateAsync(Guid id) {
			return await _manager.GetRateAsync(id);
		}

		[HttpPost("create")]
		public async Task<RateDto> CreateRateAsync(InsertRateDto data) {
			return await _manager.AddRateAsync(data);
		}

		[HttpPatch("update")]
		public async Task<RateDto> UpdateRateAsync(Guid id, [FromBody] InsertRateDto data) {
			return await _manager.UpdateRateAsync(id, data);
		}

		[HttpDelete("delete/{id}")]
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			return await _manager.DeleteRateAsync(id);
		}
	}
}
