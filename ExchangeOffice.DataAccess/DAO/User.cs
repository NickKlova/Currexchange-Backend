namespace ExchangeOffice.DataAccess.DAO {
	public class User {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public string? Login { get; set; }
		public string? PasswordHash { get; set; }
		public Guid? RoleId { get; set; }
		public UserRole? Role { get; set; }
		public Guid? ContactId { get; set; }
		public Contact? Contact { get; set; }
		public bool IsActive { get; set; }
	}
}
