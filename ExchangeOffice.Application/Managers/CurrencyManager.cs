using AutoMapper;
using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;
using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.Integration.BankGov.Managers.Interfaces;
using ExchangeOffice.Integration.BankGov.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExchangeOffice.Application.Managers {
	public class CurrencyManager : ICurrencyManager {
		#region Fields: Private
		private readonly ICurrencyService _service;
		private readonly IFundManager _fundManager;
		private readonly IRateManager _rateManager;
		private readonly IBankGovManager _bankGovManager;
		private readonly IMapper _mapper;
		#endregion

		#region Constructors: Public
		public CurrencyManager(ICurrencyService service, IFundManager fundManager, IRateManager rateManager, IBankGovManager bankGovManager, IMapper mapper) {
			_service = service;
			_fundManager = fundManager;
			_bankGovManager = bankGovManager;
			_rateManager = rateManager;
			_mapper = mapper;
		}
		#endregion

		#region Methods: Private

		private async Task<FundDto> CreateFundAsync(Guid currencyId) {
			var fundEntity = new InsertFundDto() {
				CurrencyId = currencyId,
				Amount = 0
			};
			return await _fundManager.AddFundAsync(fundEntity);
		}
		private async Task<BankGovRate> GetBankGovRate(string bankGovId) {
			var rates = await _bankGovManager.GetRatesAsync();
			var rate = rates.Where(x => x.Id == bankGovId).FirstOrDefault();
			if (rate == null) {
				// TODO: Change exception to global commons
				throw new Exception("");
			}
			return rate;
		}
		private async Task<RateDto> CreateRateAsync(Guid currencyId, string bankGovId) {
			var rate = await GetBankGovRate(bankGovId);
			var rateEntity = new InsertRateDto() {
				CurrencyId = currencyId,
				// TODO: % of income change to another place
				BuyRate = rate.Rate * 1.05m,
				SellRate = rate.Rate * 0.95m,
			};
			return await _rateManager.AddRateAsync(rateEntity);
		}

		private async Task ActivateDeletedCurrency(CurrencyDto entity, InsertCurrencyDto data) {
			await _service.ActivateCurrencyAsync(entity.Id, data);
			var deletedFunds = await _fundManager.GetDeletedFundsAsync();
			var deletedFund = deletedFunds.Where(x => x.Currency.Id == entity.Id).FirstOrDefault();
			if (deletedFund != null) {
				var insertFund = _mapper.Map<InsertFundDto>(deletedFund);
				await _fundManager.ActivateDeletedFundAsync(deletedFund.Id, insertFund);
			}

			var deletedRates = await _rateManager.GetDeletedRates();
			var deletedRate = deletedRates.Where(x => x.Currency.Id == entity.Id).FirstOrDefault();
			if (deletedRate != null) {
				var rate = await GetBankGovRate(entity.BankGovId);
				var rateEntity = new InsertRateDto() {
					CurrencyId = entity.Id,
					// TODO: % of income change to another place
					BuyRate = rate.Rate * 1.05m,
					SellRate = rate.Rate * 0.95m,
				};
				await _rateManager.ActivateDeletedRateAsync(deletedRate.Id, rateEntity);
			}
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync() {
			return await _service.GetCurrenciesAsync();
		}
		public async Task<IEnumerable<BankGovCurrency>> GetBankGovCurrencies() {
			return await _bankGovManager.GetCurrenciesAsync();
		}
		public async Task<CurrencyDto> GetCurrencyAsync(Guid id) {
			return await _service.GetCurrencyAsync(id);
		}
		public async Task<CurrencyDto> AddCurrencyAsync(InsertCurrencyDto data) {
			var deletedCurrencies = await _service.GetDeletedCurrenciesAsync();
			var deletedCurrency = deletedCurrencies.Where(x=>x.Code == data.Code).FirstOrDefault();
			if (deletedCurrency != null) {
				await ActivateDeletedCurrency(deletedCurrency, data);
			}

			var currency = await _service.AddCurrencyAsync(data);
			await CreateFundAsync(currency.Id);
			if (!string.IsNullOrEmpty(currency.BankGovId)) {
				await CreateRateAsync(currency.Id, currency.BankGovId);
			}
			return currency;
		}
		public async Task<CurrencyDto> UpdateCurrencyAsync(Guid id, InsertCurrencyDto entity) {
			return await _service.UpdateCurrencyAsync(id, entity);
		}
		public async Task<CurrencyDto> DeleteCurrencyAsync(Guid id) {
			var fund = await _fundManager.GetFundByCurrencyIdAsync(id);
			await _fundManager.DeleteFundAsync(fund.Id);
			return await _service.DeleteCurrencyAsync(id);
		}

		#endregion
	}
}
