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

		[HttpGet("get/all")]
		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			return await _manager.GetRatesAsync();
		}

		[HttpGet("get/bycurrency/{currencyId}")]
		public async Task<RateDto> GetRateByCurrencyAsync(Guid currencyId) {
			return await _manager.GetRateByCurrencyAsync(currencyId);
		}

		[HttpGet("get/{id}")]
		public async Task<RateDto> GetRateAsync(Guid id) {
			return await _manager.GetRateAsync(id);
		}

		[HttpPost("create")]
		public async Task<RateDto> CreateRateAsync(InsertRateDto data) {
			return await _manager.AddRateAsync(data);
		}

		[HttpPut("update/{id}")]
		public async Task<RateDto> UpdateRateAsync(Guid id, [FromBody] InsertRateDto data) {
			return await _manager.UpdateRateAsync(id, data);
		}

		[HttpDelete("delete/{id}")]
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			return await _manager.DeleteRateAsync(id);
		}
	}
}
