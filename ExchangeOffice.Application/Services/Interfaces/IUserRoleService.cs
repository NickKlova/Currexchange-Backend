using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Services.Interfaces {
	public interface IUserRoleService {
		public Task<IEnumerable<UserRoleDto>> GetRolesAsync();
	}
}
