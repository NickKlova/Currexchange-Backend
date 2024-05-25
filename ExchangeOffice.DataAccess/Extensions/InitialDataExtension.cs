using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.DataAccess.Extensions {
	public static class InitialDataExtension {
		public static List<UserRole> GetUserRoles() {
			return new List<UserRole> {
				new UserRole() {
					Id = new Guid("D2E6FA3F-4D4C-4E5F-9F15-90C8FEA98721"),
					CreatedOn = DateTime.UtcNow,
					Name = "Owner"
				},
				new UserRole() {
					Id = new Guid("A9B8C7D6-5E4F-3A2B-1C0D-F9E8D7C6B5A4"),
					CreatedOn = DateTime.UtcNow,
					Name = "Manager"
				},
				new UserRole() {
					Id = new Guid("F1E2D3C4-B5A6-6C7D-8E9F-0A1B2C3D4E5F"),
					CreatedOn = DateTime.UtcNow,
					Name = "Cashier"
				},
				new UserRole() {
					Id = new Guid("7F6E5D4C-3B2A-1F0E-9D8C-2B1A0F9E8D7C"),
					CreatedOn = DateTime.UtcNow,
					Name = "User"
				}
			};
		}

		public static List<Currency> GetCurrencies() {
			return new List<Currency> {
				new Currency() {
					Id = new Guid("A3B1C2D3-4E5F-6789-ABCD-EF0123456789"),
					Code = "UAH",
					CreatedOn = DateTime.UtcNow,
					Description = "Українська гривня",
					Symbol = "₴",
					IsActive = true,
				},
			};
		}

		public static List<Fund> GetFunds() {
			return new List<Fund> {
				new Fund() { 
					Id = new Guid("BC0FA8E3-4A15-4D19-BA0B-2EF80AB94C56"),
					CreatedOn = DateTime.UtcNow,
					CurrencyId = new Guid("A3B1C2D3-4E5F-6789-ABCD-EF0123456789"),
					Amount = 0,
					IsActive = true,
				}
			};
		}
	}
}
