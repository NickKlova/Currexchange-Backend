using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/fund")]
	[ApiController]
	public class FundController : ControllerBase {
		private readonly IFundManager _manager;
		public FundController(IFundManager manager) {
			_manager = manager;
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("getall")]
		public async Task<IEnumerable<FundDto>> GetFundsAsync() {
			return await _manager.GetFundsAsync();
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("get/bycurrency/{currencyId}")]
		public async Task<FundDto> GetFundByCurrencyIdAsync(Guid currencyId) {
			return await _manager.GetFundByCurrencyIdAsync(currencyId);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("get/{id}")]
		public async Task<FundDto> GetFundAsync(Guid id) {
			return await _manager.GetFundAsync(id);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPost("create")]
		public async Task<FundDto> CreateFundAsync(InsertFundDto data) {
			return await _manager.AddFundAsync(data);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPatch("update/bycurrency/{currencyId}")]
		public async Task<FundDto> UpdateFundByCurrencyIdAsync(Guid currencyId, decimal amount) {
			return await _manager.UpdateFundByCurrencyIdAsync(currencyId, amount);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPatch("update/{id}")]
		public async Task<FundDto> UpdateFundAsync(Guid id, InsertFundDto data) {
			return await _manager.UpdateFundAsync(id, data);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpDelete("delete/{id}")]
		public async Task<FundDto> DeleteFundAsync(Guid id) {
			return await _manager.DeleteFundAsync(id);
		}
	}
}
