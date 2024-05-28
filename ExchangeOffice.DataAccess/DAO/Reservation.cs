namespace ExchangeOffice.DataAccess.DAO {
	public class Reservation {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public Guid ContactId { get; set; }
		public Guid StatusId { get; set; }
		public ReservationStatus Status { get; set; }
		public Guid OperationId { get; set; }
		public OperationType OperationType { get; set; }
		public Contact? Contact { get; set; }
		public Guid RateId { get; set; }
		public Rate? Rate { get; set; }
		public decimal Amount { get; set; }
		public bool IsActive { get; set; }
	}
}
