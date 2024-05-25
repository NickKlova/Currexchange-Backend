using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Application.Managers {
	public class TransactionManager : ITransactionManager {
		private readonly ITransactionService _service;
		private readonly IFundManager _fundManager;
		private readonly IRateManager _rateManager;
		public TransactionManager(ITransactionService service, IFundManager fundManager, IRateManager rateManager) {
			_service = service;
			_fundManager = fundManager;
			_rateManager = rateManager;
		}

		public async Task<TransactionDto> CreateTransactionAsync(InsertTransactionDto transaction) {
			//var baseCurrencyAmount = transaction.Amount;
			//var rate = await GetCurrentRateAsync(transaction.RateId);
			//decimal targetAmount;
			//if (transaction.IsSale) {
			//	targetAmount = -(rate.SellRate * baseCurrencyAmount);
			//	await UpdateFundAsync(rate.TargetCurrency.Id, targetAmount);
			//	await UpdateFundAsync(rate.BaseCurrency.Id, baseCurrencyAmount);
			//	return await _service.CreateTransactionAsync(transaction);
			//}

			//targetAmount = rate.BuyRate * baseCurrencyAmount;
			//await UpdateFundAsync(rate.TargetCurrency.Id, targetAmount);
			//await UpdateFundAsync(rate.BaseCurrency.Id, -baseCurrencyAmount);
			return await _service.CreateTransactionAsync(transaction);
		}

		private async Task<RateDto> GetCurrentRateAsync(Guid rateId) {
			return await _rateManager.GetRateByCurrenciesAsync(rateId, rateId);

		}

		private async Task UpdateFundAsync(Guid currencyId, decimal amount) {
			await _fundManager.UpdateFundByCurrencyIdAsync(currencyId, amount);
		}

		public async Task<TransactionDto> DeleteTransactionAsync(Guid id) {
			return await _service.DeleteTransactionAsync(id);
		}

		public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync() {
			return await _service.GetTransactionsAsync();
		}

		public async Task<TransactionDto> UpdateTransactionAsync(Guid id, InsertTransactionDto transaction) {
			var baseCurrencyAmount = transaction.Amount;
			var rate = await GetCurrentRateAsync(transaction.RateId);
			decimal targetAmount;
			if (transaction.IsSale) {
				targetAmount = -(rate.SellRate * baseCurrencyAmount);
				//await UpdateFundAsync(rate.TargetCurrency.Id, targetAmount);
				//wait UpdateFundAsync(rate.BaseCurrency.Id, baseCurrencyAmount);
				return await _service.UpdateTransactionAsync(id, transaction);
			}

			targetAmount = rate.BuyRate * baseCurrencyAmount;
			//await UpdateFundAsync(rate.TargetCurrency.Id, targetAmount);
			//await UpdateFundAsync(rate.BaseCurrency.Id, -baseCurrencyAmount);
			return await _service.UpdateTransactionAsync(id, transaction);
		}
	}
}
