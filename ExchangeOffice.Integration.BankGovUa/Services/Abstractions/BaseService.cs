using ExchangeOffice.Common.Exceptions;

namespace ExchangeOffice.Integration.BankGov.Services.Abstractions {
	public abstract class BaseService {
		public async Task<string> GetAsync(string url) {
			using (HttpClient client = new HttpClient()) {
				var response = await client.GetAsync(url);
				if (!response.IsSuccessStatusCode) {
					throw new BankGovException(500, "Integration.BankGov", "Can't connect to bank gov api");
				}

				string responseBody = await response.Content.ReadAsStringAsync();
				return responseBody;
			}
		}
	}
}
