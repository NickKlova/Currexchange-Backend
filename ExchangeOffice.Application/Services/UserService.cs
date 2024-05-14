using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	internal class UserService : IUserService {
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;

		public UserService(IUserRepository repo, IMapper mapper) {
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<UserDto> GetUserAsync(string login) {
			var dao = await _repo.GetUserAsync(login);
			var dto = _mapper.Map<UserDto>(dao);
			return dto;
		}
		public async Task<UserDto> AddUserAsync(InsertUserDto entity) {
			var dao = _mapper.Map<User>(entity);
			var resultDao = await _repo.AddUserAsync(dao);
			var dto = _mapper.Map<UserDto>(resultDao);
			return dto;
		}
		public async Task<UserDto> ChangeUserRoleAsync(string login, Guid roleId) {
			var dao = await _repo.ChangeUserRoleAsync(login, roleId);
			var dto = _mapper.Map<UserDto>(dao);
			return dto;
		}
		public async Task<UserDto> DeleteUserAsync(string login) {
			var dao = await _repo.DeleteUserAsync(login);
			var dto = _mapper.Map<UserDto>(dao);
			return dto;
		}
	}
}
