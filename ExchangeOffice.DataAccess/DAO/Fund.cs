namespace ExchangeOffice.DataAccess.DAO {
	public class Fund {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public Guid CurrencyId { get; set; }
		public Currency? Currency { get; set; }
		public decimal Amount { get; set; }
		public bool IsActive { get; set; }
	}
}
