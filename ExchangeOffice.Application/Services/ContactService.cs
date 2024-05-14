using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Repositories.Interfaces;

namespace ExchangeOffice.Application.Services {
	public class ContactService : IContactService {
		private readonly IMapper _mapper;
		private readonly IContactRepository _repo;
		public ContactService(IMapper mapper, IContactRepository repo) {
			_mapper = mapper;
			_repo = repo;
		}

		public async Task<IEnumerable<ContactDto>> GetContactsAsync() {
			var daos = await _repo.GetContactsAsync();
			var dtos = _mapper.Map<IEnumerable<ContactDto>>(daos);
			return dtos;
		}
		public async Task<ContactDto> GetContactAsync(Guid id) {
			var dao = await _repo.GetContactAsync(id);
			var dto = _mapper.Map<ContactDto>(dao);
			return dto;
		}
		public async Task<ContactDto> AddContactAsync(InsertContactDto entity) {
			var dao = _mapper.Map<Contact>(entity);
			var resultDao = await _repo.AddContactAsync(dao);
			var dto = _mapper.Map<ContactDto>(resultDao);
			return dto;
		}
		public async Task<ContactDto> UpdateContactAsync(Guid id,InsertContactDto entity) {
			var dao = _mapper.Map<Contact>(entity);
			dao.Id = id;
			var resultDao = await _repo.UpdateContactAsync(dao);
			var dto = _mapper.Map<ContactDto>(resultDao);
			return dto;
		}
		public async Task<ContactDto> DeactivateContactAsync(Guid id) {
			var dao = await _repo.DeactivateContactAsync(id);
			var dto = _mapper.Map<ContactDto>(dao);
			return dto;
		}
		public async Task<ContactDto> DeleteContactAsync(Guid id) {
			var dao = await _repo.DeleteContactAsync(id);
			var dto = _mapper.Map<ContactDto>(dao);
			return dto;
		}
	}
}
