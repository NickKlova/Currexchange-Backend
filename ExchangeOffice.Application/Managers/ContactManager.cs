using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;

namespace ExchangeOffice.Application.Managers {
	public class ContactManager : IContactManager {
		private readonly IContactService _service;
		public ContactManager(IContactService service) {
			_service = service;
		}

		public async Task<IEnumerable<ContactDto>> GetContactsAsync() {
			return await _service.GetContactsAsync();
		}
		public async Task<ContactDto> GetContactAsync(Guid id) {
			return await _service.GetContactAsync(id);
		}
		public async Task<ContactDto> AddContactAsync(InsertContactDto entity) {
			return await _service.AddContactAsync(entity);
		}
		public async Task<ContactDto> UpdateContactAsync(Guid id, InsertContactDto entity) {
			return await _service.UpdateContactAsync(id, entity);
		}
		public async Task<ContactDto> DeactivateContactAsync(Guid id) {
			return await _service.DeactivateContactAsync(id);
		}
		public async Task<ContactDto> DeleteContactAsync(Guid id) {
			return await _service.DeleteContactAsync(id);
		}
	}
}
