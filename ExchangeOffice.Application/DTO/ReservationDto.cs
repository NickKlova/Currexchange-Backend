namespace ExchangeOffice.Application.DTO {
	public class ReservationDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public ContactDto? Contact { get; set; }
		public RateDto? Rate { get; set; }
		public decimal Amount { get; set; }
		public bool IsSell { get; set; }
		public bool IsActual { get; set; }
	}

	public class InsertReservationDto {
		public Guid ContactId { get; set; }
		public Guid RateId { get; set; }
		public decimal Amount { get; set; }
		public bool IsSell { get; set; }
	}
}
