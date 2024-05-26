using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/fund")]
	[ApiController]
	public class FundController : ControllerBase {
		private readonly IFundManager _manager;
		public FundController(IFundManager manager) {
			_manager = manager;
		}

		[HttpGet("get/all")]
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			return await _manager.GetFundsAsync();
		}

		[HttpGet("get/bycurrency/{currencyId}")]
		public async Task<FundDto> GetFundByCurrencyIdAsync(Guid currencyId) {
			return await _manager.GetFundByCurrencyIdAsync(currencyId);
		}

		[HttpGet("get/{id}")]
		public async Task<FundDto> GetFundAsync(Guid id) {
			return await _manager.GetFundAsync(id);
		}

		[HttpPost("create")]
		public async Task<FundDto> CreateFundAsync(InsertFundDto data) {
			return await _manager.AddFundAsync(data);
		}

		[HttpPut("update/bycurrency/{currencyId}")]
		public async Task<FundDto> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount) {
			return await _manager.UpdateFundByCurrencyIdAsync(currencyId, amount);
		}

		[HttpPut("update/{id}")]
		public async Task<FundDto> UpdateFundAsync(Guid id, InsertFundDto data) {
			return await _manager.UpdateFundAsync(id, data);
		}

		[HttpDelete("delete/{id}")]
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			return await _manager.DeleteFundAsync(id);
		}
	}
}
