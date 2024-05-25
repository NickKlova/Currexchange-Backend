namespace ExchangeOffice.Integration.BankGovUa.Services.Interfaces {
	public interface IBankGovService {
		public Task<string> GetRatesAsync();
	}
}
