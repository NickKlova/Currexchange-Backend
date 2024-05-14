using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/role")]
	[ApiController]
	public class RoleController : ControllerBase {
		private readonly IUserRoleManager _manager;
		public RoleController(IUserRoleManager manager) {
			_manager = manager;
		}

		[HttpGet("getall")]
		public async Task<IEnumerable<UserRoleDto>> GetRoles() {
			return await _manager.GetRolesAsync();
		}
	}
}
