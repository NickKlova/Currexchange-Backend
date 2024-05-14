using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/contact")]
	[ApiController]
	public class ContactController : ControllerBase {
		private readonly IContactManager _manager;
		public ContactController(IContactManager manager) {
			_manager = manager;
		}

		[HttpGet("getall")]
		public async Task<IEnumerable<ContactDto>> GetContactsAsync() {
			return await _manager.GetContactsAsync();
		}

		[HttpGet("get")]
		public async Task<ContactDto> GetContactAsync(Guid id) {
			return await _manager.GetContactAsync(id);
		}

		[HttpPost("create")]
		public async Task<ContactDto> CreateContactAsync(InsertContactDto data) {
			return await _manager.AddContactAsync(data);
		}

		[HttpPatch("update")]
		public async Task<ContactDto> UpdateContactAsync(Guid id, [FromBody] InsertContactDto data) {
			return await _manager.UpdateContactAsync(id, data);
		}

		[HttpPatch("deactivate")]
		public async Task<ContactDto> DeactivateContactAsync(Guid id) {
			return await _manager.DeactivateContactAsync(id);
		}

		[HttpDelete("delete")]
		public async Task<ContactDto> DeleteContactAsync(Guid id) {
			return await _manager.DeleteContactAsync(id);
		}
	}
}
