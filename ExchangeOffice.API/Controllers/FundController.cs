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

		[HttpGet("getall")]
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			return await _manager.GetFundsAsync();
		}

		[HttpGet("get")]
		public async Task<FundDto> GetFundAsync(Guid currencyId) {
			return await _manager.GetFundAsync(currencyId);
		}

		[HttpGet("getById")]
		public async Task<FundDto> GetFundByIdAsync(Guid id) {
			return await _manager.GetFundByIdAsync(id);
		}

		[HttpPost("create")]
		public async Task<FundDto> CreateFundAsync(InsertFundDto data) {
			return await _manager.AddFundAsync(data);
		}

		[HttpPatch("update")]
		public async Task<FundDto> UpdateFundAsync(Guid currencyId, decimal amount) {
			return await _manager.UpdateFundAsync(currencyId, amount);
		}

		[HttpPatch("updateById")]
		public async Task<FundDto> UpdateFundByIdAsync(Guid id, InsertFundDto data) {
			return await _manager.UpdateFundByIdAsync(id, data);
		}

		[HttpDelete("delete")]
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			return await _manager.DeleteFundAsync(id);
		}
	}
}
