using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.Application.DTO {
	public class ReservationDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public ReservationStatusDto Status { get; set; }
		public OperationTypeDto OperationType { get; set; }
		public ContactDto? Contact { get; set; }
		public RateDto? Rate { get; set; }
		public decimal Amount { get; set; }
		public bool IsActive { get; set; }
	}

	public class InsertReservationDto {
		public Guid ContactId { get; set; }
		public Guid RateId { get; set; }
		public Guid OperationId { get; set; }
		public Guid StatusId { get; set; }
		public decimal Amount { get; set; }
	}
}
