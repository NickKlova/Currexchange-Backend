using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class UserRoleManager : IUserRoleManager {
		private readonly IUserRoleService _service;
		public UserRoleManager(IUserRoleService service) {
			_service = service;
		}

		public Task<IEnumerable<UserRoleDto>> GetRolesAsync() {
			return _service.GetRolesAsync();
		}
	}
}
