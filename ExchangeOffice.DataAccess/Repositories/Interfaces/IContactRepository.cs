using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Repositories.Interfaces {
	public interface IContactRepository {
		public Task<IEnumerable<Contact>> GetContactsAsync();
		public Task<Contact> GetContactAsync(Guid id);
		public Task<Contact> AddContactAsync(Contact entity);
		public Task<Contact> UpdateContactAsync(Contact entity);
		public Task<Contact> DeactivateContactAsync(Guid id);
		public Task<Contact> DeleteContactAsync(Guid id);
	}
}
