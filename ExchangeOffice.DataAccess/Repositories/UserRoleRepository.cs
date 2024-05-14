using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess.Repositories {
	public class UserRoleRepository : IUserRoleRepository {
		private readonly DataAccessContext _context;
		public UserRoleRepository(DataAccessContext context) {
			_context = context;
		}

		public async Task<IEnumerable<UserRole>> GetRolesAsync() {
			return await Task.FromResult(_context.UserRoles.AsNoTracking().AsEnumerable());
		}
	}
}
