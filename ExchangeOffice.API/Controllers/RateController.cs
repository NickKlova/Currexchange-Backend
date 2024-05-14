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

		[HttpGet("getall")]
		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			return await _manager.GetRatesAsync();
		}

		[HttpGet("get")]
		public async Task<RateDto> GetRateAsync(Guid baseCurrency, Guid targetCurrency) {
			return await _manager.GetRateAsync(baseCurrency, targetCurrency);
		}

		[HttpGet("getById")]
		public async Task<RateDto> GetRateByIdAsync(Guid id) {
			return await _manager.GetRateByIdAsync(id);
		}

		[HttpPost("create")]
		public async Task<RateDto> CreateRateAsync(InsertRateDto data) {
			return await _manager.AddRateAsync(data);
		}

		[HttpPatch("update")]
		public async Task<RateDto> UpdateRateAsync(Guid id, [FromBody] InsertRateDto data) {
			return await _manager.UpdateRateAsync(id, data);
		}

		[HttpDelete("delete")]
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			return await _manager.DeleteRateAsync(id);
		}
	}
}
