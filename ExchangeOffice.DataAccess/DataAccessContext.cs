using ExchangeOffice.DataAccess.DAO;
using ExchangeOffice.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ExchangeOffice.DataAccess {
	public class DataAccessContext : DbContext {
		public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options) { }

		public DbSet<Currency> Currencies { get; set; }
		public DbSet<Rate> Rates { get; set; }
		public DbSet<Fund> Funds { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<OperationType> OperationTypes { get; set; }
		public DbSet<ReservationStatus> ReservationStatuses { get; set; }
		public DbSet<TransactionType> TransactionTypes { get; set; }
		public DbSet<IssuanceLog> IssuanceLogs { get; set; }
		public DbSet<ExchangeSetting> ExchangeSettings { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Rate>()
				.HasOne(r => r.Currency)
				.WithMany()
				.HasForeignKey(r => r.CurrencyId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Fund>()
				.HasOne(r => r.Currency)
				.WithMany()
				.HasForeignKey(r => r.CurrencyId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<User>()
				.HasOne(r => r.Role)
				.WithMany()
				.HasForeignKey(r => r.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<User>()
				.HasOne(r=>r.Contact)
				.WithMany()
				.HasForeignKey(r=>r.ContactId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<User>()
				.Property(r => r.ContactId)
				.IsRequired(false);
			
			modelBuilder.Entity<Transaction>()
				.HasOne(r => r.Contact)
				.WithMany()
				.HasForeignKey(r => r.ContactId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Transaction>()
				.HasOne(r => r.RateLog)
				.WithMany()
				.HasForeignKey(r => r.RateLogId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Transaction>()
				.HasOne(r => r.OperationType)
				.WithMany()
				.HasForeignKey(r => r.OperationId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Transaction>()
				.HasOne(r=>r.TransactionType)
				.WithMany()
				.HasForeignKey(r => r.TypeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Contact)
				.WithMany()
				.HasForeignKey(r => r.ContactId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Rate)
				.WithMany()
				.HasForeignKey(r => r.RateId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.Status)
				.WithMany()
				.HasForeignKey(r => r.StatusId);

			modelBuilder.Entity<Reservation>()
				.HasOne(r => r.OperationType)
				.WithMany()
				.HasForeignKey(r => r.OperationId);

			modelBuilder.Entity<UserRole>()
				.HasData(InitialDataExtension.GetUserRoles());

			modelBuilder.Entity<Currency>()
				.HasData(InitialDataExtension.GetCurrencies());

			modelBuilder.Entity<Currency>()
				.HasIndex(e => e.BankGovId)
				.IsUnique();

			modelBuilder.Entity<Fund>()
				.HasData(InitialDataExtension.GetFunds());

			modelBuilder.Entity<ReservationStatus>()
				.HasData(InitialDataExtension.GetReservationStatuses());

			modelBuilder.Entity<OperationType>()
				.HasData(InitialDataExtension.GetOperationTypes());

			modelBuilder.Entity<TransactionType>()
				.HasData(InitialDataExtension.GetTransactionTypes());

			modelBuilder.Entity<ExchangeSetting>()
				.HasData(InitialDataExtension.GetExchangeSettings());
		}
	}
}
