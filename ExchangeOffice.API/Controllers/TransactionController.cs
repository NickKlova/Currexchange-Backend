using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/transaction")]
	[ApiController]
	public class TransactionController : ControllerBase {
		private readonly ITransactionManager _manager;
		public TransactionController(ITransactionManager manager) {
			_manager = manager;
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("getall")]
		public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync() {
			return await _manager.GetTransactionsAsync();
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPost("create")]
		public async Task<TransactionDto> CreateTransactionAsync(InsertTransactionDto data) {
			return await _manager.CreateTransactionAsync(data);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPatch("update")]
		public async Task<TransactionDto> UpdateTransactionAsync(Guid id, [FromBody] InsertTransactionDto data) {
			return await _manager.UpdateTransactionAsync(id, data);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpDelete("delete")]
		public async Task<TransactionDto> DeleteTransaction(Guid id) {
			return await _manager.DeleteTransactionAsync(id);
		}
	} 
}
