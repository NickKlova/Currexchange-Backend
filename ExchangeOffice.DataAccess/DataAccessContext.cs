using ExchangeOffice.DataAccess.DAO;
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
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<Rate>()
				.HasOne(r => r.BaseCurrency)
				.WithMany()
				.HasForeignKey(r => r.BaseCurrencyId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Rate>()
				.HasOne(r => r.TargetCurrency)
				.WithMany()
				.HasForeignKey(r => r.TargetCurrencyId)
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
				.Property(r => r.RoleId)
				.IsRequired(false);
			modelBuilder.Entity<User>()
				.Property(r => r.ContactId)
				.IsRequired(false);
			
			modelBuilder.Entity<Transaction>()
				.HasOne(r => r.Contact)
				.WithMany()
				.HasForeignKey(r => r.ContactId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Transaction>()
				.HasOne(r => r.Rate)
				.WithMany()
				.HasForeignKey(r => r.RateId)
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
		}
	}
}
