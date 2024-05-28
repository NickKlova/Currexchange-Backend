using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.Application.DTO {
	public class TransactionDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public Guid ContactId { get; set; }
		public ContactDto? Contact { get; set; }
		public Guid? RateLogId { get; set; }
		public IssuanceLogDto? RateLog { get; set; }
		public Guid OperationId { get; set; }
		public OperationTypeDto OperationType { get; set; }
		public Guid TypeId { get; set; }
		public TransactionTypeDto TransactionType { get; set; }
		public Guid? ReservationId { get; set; }
		public ReservationDto? Reservation { get; set; }
		public decimal Amount { get; set; }
		public bool IsActive { get; set; }
	}

	public class InsertTransactionDto {
		public Guid ContactId { get; set; }
		public InsertIssuanceLogDto RateLog {  get; set; }
		public Guid OperationId { get; set; }
		public Guid TypeId { get; set; }
		public Guid? ReservationId { get; set; }
		public decimal Amount { get; set; }
	}
}
