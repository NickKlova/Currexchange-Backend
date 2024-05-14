using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IUserRepository {
		public Task<User> GetUserAsync(string login);
		public Task<User> AddUserAsync(User entity);
		public Task<User> ChangeUserRoleAsync(string login, Guid roleId);
		public Task<User> DeleteUserAsync(string login);
	}
}
