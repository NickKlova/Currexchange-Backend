namespace ExchangeOffice.Application.DTO {
	public class ContactDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public bool IsBlacklist { get; set; }
		public bool IsActive { get; set; }
	}

	public class InsertContactDto {
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public bool IsBlacklist { get; set; }
	}
}
