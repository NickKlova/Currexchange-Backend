using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/user")]
	[ApiController]
	public class AuthController : ControllerBase {
		private readonly IUserManager _manager;
		public AuthController(IUserManager manager) {
			_manager = manager;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(string login, string password) {
			var data = await _manager.LoginAsync(login, password);
			return Ok(data);
		}

		[HttpPost("register")]
		public async Task Register(InsertUserDto data) {
			await _manager.RegisterAsync(data);
		}

		[Authorize(Roles = "Owner")]
		[HttpPut("changerole")]
		public async Task ChangeRole(string login, Guid roleId) {
			await _manager.ChangeUserRoleAsync(login, roleId);
		}

		[Authorize(Roles = "Owner")]
		[HttpDelete("deactivate")]
		public async Task DeactivateUser(string login) {
			await _manager.DeactivateUserAsync(login);
		}
	}
}
