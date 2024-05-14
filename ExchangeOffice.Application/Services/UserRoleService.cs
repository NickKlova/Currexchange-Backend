using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class UserRoleService : IUserRoleService {
		private readonly IMapper _mapper;
		private readonly IUserRoleRepository _repo;
		public UserRoleService(IMapper mapper, IUserRoleRepository repo) {
			_mapper = mapper;
			_repo = repo;
		}

		public async Task<IEnumerable<UserRoleDto>> GetRolesAsync() {
			var daos = await _repo.GetRolesAsync();
			var dtos = _mapper.Map<IEnumerable<UserRoleDto>>(daos);
			return dtos;
		}
	}
}
