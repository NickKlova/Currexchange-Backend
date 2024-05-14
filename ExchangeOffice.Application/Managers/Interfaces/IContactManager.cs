using ExchangeOffice.Application.DTO;

namespace ExchangeOffice.Application.Managers.Interfaces {
	public interface IContactManager {
		public Task<IEnumerable<ContactDto>> GetContactsAsync();
		public Task<ContactDto> GetContactAsync(Guid id);
		public Task<ContactDto> AddContactAsync(InsertContactDto entity);
		public Task<ContactDto> UpdateContactAsync(Guid id, InsertContactDto entity);
		public Task<ContactDto> DeactivateContactAsync(Guid id);
		public Task<ContactDto> DeleteContactAsync(Guid id);
	}
}
