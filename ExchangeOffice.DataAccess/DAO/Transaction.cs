namespace ExchangeOffice.DataAccess.DAO {
	public class Transaction {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public Guid ContactId { get; set; }
		public Contact? Contact { get; set; }
		public Guid? RateLogId { get; set; }
		public IssuanceLog? RateLog { get; set; }
		public Guid OperationId { get; set; }
		public OperationType OperationType { get; set; }
		public Guid TypeId { get; set; }
		public TransactionType TransactionType { get; set; }
		public Guid? ReservationId { get; set; }
		public Reservation? Reservation { get; set; }
		public decimal Amount { get; set; }
		public bool IsActive { get; set; }
	}
}
