using ExchangeOffice.DataAccess;
using ExchangeOffice.DataAccess.DAO.Mappers;
using ExchangeOffice.DataAccess.Repositories;
using ExchangeOffice.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DataAccessExtensions {
	public static void AddDataAccessLayer(this IServiceCollection services) {
		services.AddDbContext<DataAccessContext>(options =>
			options.UseNpgsql("Server=localhost;Port=5432;Database=currency_exchange_dev;User Id=postgres;Password=postgres;"), ServiceLifetime.Singleton);
		services.AddSingleton<DataAccessContext>();
		services.AddAutoMapper(typeof(AutoMapperProfile));
		services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
		services.AddSingleton<IRateRepository, RateRepository>();
		services.AddSingleton<IFundRepository, FundRepository>();
		services.AddSingleton<IContactRepository, ContactRepository>();
		services.AddSingleton<IUserRepository, UserRepository>();
		services.AddSingleton<IUserRoleRepository, UserRoleRepository>();
		services.AddSingleton<ITransactionRepository, TransactionRepository>();
		services.AddSingleton<IReservationRepository, ReservationRepository>();
	}
}