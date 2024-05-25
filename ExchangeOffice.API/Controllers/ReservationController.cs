using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/reservation")]
	[ApiController]
	public class ReservationController : ControllerBase {
		private readonly IReservationManager _manager;
		public ReservationController(IReservationManager manager) {
			_manager = manager;
		}

		[HttpGet("getall")]
		public async Task<IEnumerable<ReservationDto>> GetReservations() {
			return await _manager.GetReservationsAsync();
		}

		[HttpGet("get")]
		public async Task<ReservationDto> GetReservationAsync(Guid id) {
			return await _manager.GetReservationAsync(id);
		} 

		[HttpPatch("update")]
		public async Task<ReservationDto> UpdateReservatuionAsync(Guid id, [FromBody] InsertReservationDto data) {
			return await _manager.UpdateReservationAsync(id, data);
		}

		//[Authorize(Roles = "Owner, Manager, Cashier, User")]
		[HttpPost("create")]
		public async Task<ReservationDto> CreateReservationAsync(InsertReservationDto data) {
			return await _manager.AddReservationAsync(data);
		}

		[HttpDelete("delete")]
		public async Task<ReservationDto> DeleteReservationAsync(Guid id) {
			return await _manager.DeleteReservationAsync(id);
		}
	}
}
