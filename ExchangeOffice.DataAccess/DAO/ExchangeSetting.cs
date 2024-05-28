namespace ExchangeOffice.DataAccess.DAO {
	public class ExchangeSetting {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public decimal PercantageTransactionIncome { get; set; }
		public Guid BaseCurrencyId { get; set; }
		public Currency BaseCurrency { get; set; }
		public decimal LowBalanceThreshold { get; set; }
		public decimal HighTransactionThreshold { get; set; }
	}
}
