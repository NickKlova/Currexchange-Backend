using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IUserRoleRepository {
		public Task<IEnumerable<UserRole>> GetRolesAsync();
	}
}
