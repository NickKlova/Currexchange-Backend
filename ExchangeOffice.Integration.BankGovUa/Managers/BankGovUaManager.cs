using ExchangeOffice.Common.Exceptions;
using ExchangeOffice.Integration.BankGov.Managers.Interfaces;
using ExchangeOffice.Integration.BankGov.Models;
using ExchangeOffice.Integration.BankGovUa.Services.Interfaces;
using Newtonsoft.Json;

namespace ExchangeOffice.Integration.BankGov.Managers
{
    public class BankGovUaManager : IBankGovManager {
		private readonly IBankGovService _service;
		public BankGovUaManager(IBankGovService service) {
			_service = service;
		}

		public async Task<IEnumerable<BankGovCurrency>> GetCurrenciesAsync() {
			var json = await _service.GetRatesAsync();
			var entity = JsonConvert.DeserializeObject<IEnumerable<BankGovCurrency>>(json);
			if (entity == null) {
				throw new BankGovException(500, "Integration.BankGov", "Entity is empty");
			}

			return entity;
		}

		public async Task<IEnumerable<BankGovRate>> GetRatesAsync() {
			var json = await _service.GetRatesAsync();
			var entity = JsonConvert.DeserializeObject<IEnumerable<BankGovRate>>(json);
			if (entity == null) {
				throw new BankGovException(500, "Integration.BankGov", "Entity is empty");
			}

			return entity;
		}
	}
}
