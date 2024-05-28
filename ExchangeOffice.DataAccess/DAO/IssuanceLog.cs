namespace ExchangeOffice.DataAccess.DAO {
	public class IssuanceLog {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public Guid CurrencyId { get; set; }
		public Currency Currency { get; set; }
		public decimal BuyRate { get; set; }
		public decimal SellRate { get; set; }
	}
}
