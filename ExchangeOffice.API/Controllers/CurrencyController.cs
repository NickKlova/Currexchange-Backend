using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Integration.BankGov.Models;
using Microsoft.AspNetCore.Mvc;


namespace ExchangeOffice.API.Controllers {
	[Route("api/currency")]
	[ApiController]
	public class CurrencyController : ControllerBase {
		private readonly ICurrencyManager _manager;
		public CurrencyController(ICurrencyManager manager) {
			_manager = manager;
		}

		[HttpGet("gov/get/all")]
		public async Task<IEnumerable<BankGovCurrency>> GetCurrenciesGovAsync() {
			return await _manager.GetBankGovCurrencies();
		}

		[HttpGet("get/all")]
		public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync() {
			return await _manager.GetCurrenciesAsync();
		}

		[HttpGet("get/{id}")]
		public async Task<CurrencyDto> GetCurrencyAsync(Guid id) {
			return await _manager.GetCurrencyAsync(id);
		}

		[HttpPost("create")]
		public async Task<CurrencyDto> CreateCurrencyAsync(InsertCurrencyDto data) {
			return await _manager.AddCurrencyAsync(data);
		}

		[HttpPut("update/{id}")]
		public async Task<CurrencyDto> UpdateCurrencyAsync(Guid id, [FromBody]InsertCurrencyDto data) {
			return await _manager.UpdateCurrencyAsync(id, data);
		}

		[HttpDelete("delete/{id}")]
		public async Task<CurrencyDto> DeleteCurrencyAsync(Guid id) {
			return await _manager.DeleteCurrencyAsync(id);
		}
	}
}
