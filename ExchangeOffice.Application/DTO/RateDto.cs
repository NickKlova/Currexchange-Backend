namespace ExchangeOffice.Application.DTO {
	public class RateDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public CurrencyDto? Currency { get; set; }
		public decimal SellRate { get; set; }
		public decimal BuyRate { get; set; }
		public bool IsActive { get; set; }
	}
	public class InsertRateDto {
		public Guid CurrencyId { get; set; }
		public decimal SellRate { get; set; }
		public decimal BuyRate { get; set; }
	}
}
