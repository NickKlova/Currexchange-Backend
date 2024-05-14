using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Services.Interfaces {
	public interface IUserService {
		public Task<UserDto> GetUserAsync(string login);
		public Task<UserDto> AddUserAsync(InsertUserDto entity);
		public Task<UserDto> ChangeUserRoleAsync(string login, Guid roleId);
		public Task<UserDto> DeleteUserAsync(string login);
	}
}
