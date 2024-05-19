using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.Infrastructure.Providers;

namespace ExchangeOffice.Application.Managers {
	public class UserManager : IUserManager {
		private readonly IUserService _service;
		public UserManager(IUserService service) {
			_service = service;
		}

		public async Task<AuthUserDto> LoginAsync(string login, string password) {
			var user = await _service.GetUserAsync(login);
			if (user == null) {
				throw new Exception("Not found");
			}

			var isPassValid = JwtTokenProvider.VerifyPassword(password, user.PasswordHash);
			if(!isPassValid) {
				throw new Exception("Pass not valid");
			}
			var authUser = new AuthUserDto();
			authUser.User = user;
			authUser.Token = JwtTokenProvider.GenerateToken(login, user.Role.Name);
			return await Task.FromResult(authUser);
		}

		public async Task RegisterAsync(InsertUserDto data) {
			var passwordHash = JwtTokenProvider.HashPassword(data.PasswordHash);
			data.PasswordHash = passwordHash;
			await _service.AddUserAsync(data);
		}

		public async Task ChangeUserRoleAsync(string login, Guid roleId) {
			await _service.ChangeUserRoleAsync(login, roleId);
		}

		public async Task DeactivateUserAsync(string login) {
			await _service.DeleteUserAsync(login);
		}
	}
}
