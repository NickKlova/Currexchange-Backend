namespace ExchangeOffice.DataAccess.DAO {
	public class Rate {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public Guid CurrencyId { get; set; }
		public Currency? Currency { get; set; }
		public decimal SellRate { get; set; }
		public decimal BuyRate { get; set; }
		public bool IsActive { get; set; }
	}
}
