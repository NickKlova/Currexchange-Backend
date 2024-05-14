using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IUserRoleManager {
		public Task<IEnumerable<UserRoleDto>> GetRolesAsync();
	}
}
