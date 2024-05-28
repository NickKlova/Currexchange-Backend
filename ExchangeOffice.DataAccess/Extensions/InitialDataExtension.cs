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

		public static List<ReservationStatus> GetReservationStatuses() {
			return new List<ReservationStatus> {
				new ReservationStatus() {
					Id = new Guid("A1B2C3D4-E5F6-7890-ABCD-EF1234567890"),
					CreatedOn = DateTime.UtcNow,
					Name = "In progress"
				},new ReservationStatus() {
					Id = new Guid("12345678-9ABC-DEF0-1234-56789ABCDEF0"),
					CreatedOn = DateTime.UtcNow,
					Name = "Rejected"
				},new ReservationStatus() {
					Id = new Guid("8E4F2C7D-91B3-4A5F-9B6D-3E7A8B9C1D0E"),
					CreatedOn = DateTime.UtcNow,
					Name = "Confirmed"
				},new ReservationStatus() {
					Id = new Guid("E4E2D0A6-3F1B-4B4E-9441-3E1A5B7F1110"),
					CreatedOn = DateTime.UtcNow,
					Name = "Issued"
				}
			};
		}

		public static List<OperationType> GetOperationTypes() {
			return new List<OperationType> {
				new OperationType() {
					Id = new Guid("E3B0C442-98FC-1C14-9AFD-2FB77C6076F6"),
					CreatedOn = DateTime.UtcNow,
					Name = "Buy"
				},
				new OperationType() {
					Id = new Guid("C2D4E3F6-63A4-4D58-BC63-AD6E2E7B3FB6"),
					CreatedOn = DateTime.UtcNow,
					Name = "Sell"
				}
			};
		}

		public static List<TransactionType> GetTransactionTypes() {
			return new List<TransactionType> {
				new TransactionType() {
					Id = new Guid("F2C1A3E5-4D6B-4E8F-9A7C-5B1D3E4F6A7B"),
					CreatedOn = DateTime.UtcNow,
					Name = "Transaction"
				},
				new TransactionType() {
					Id = new Guid("D4F6E2A1-9C3B-4D8E-7F2A-5C1E3B4F6A9D"),
					CreatedOn = DateTime.UtcNow,
					Name = "Reservation"
				}
			};
		}

		public static List<ExchangeSetting> GetExchangeSettings() {
			return new List<ExchangeSetting> {
				new ExchangeSetting() {
					Id = new Guid("2C5011CB-2BBD-4F96-9B36-66CFCB961DC5"),
					CreatedOn = DateTime.UtcNow,
					BaseCurrencyId = new Guid("A3B1C2D3-4E5F-6789-ABCD-EF0123456789"),
					HighTransactionThreshold = 10000,
					LowBalanceThreshold = 1000,
					PercantageTransactionIncome = 0.05m,
				}
			};
		}
	}
}
