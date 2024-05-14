using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IUserManager {
		public Task<string> LoginAsync(string login, string password);
		public Task RegisterAsync(InsertUserDto data);
		public Task ChangeUserRoleAsync(string login, Guid roleId);
		public Task DeactivateUserAsync(string login);
	}
}
