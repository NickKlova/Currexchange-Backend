using ExchangeOffice.Application.DTO.Mappers;
using ExchangeOffice.Application.Managers;
using ExchangeOffice.Application.Managers.Interfaces;
using ExchangeOffice.Application.Services;
using ExchangeOffice.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeOffice.Application.Extensions {
	public static class ApplicationExtensions {
		public static void AddApplicationLayer(this IServiceCollection services) {
			services.AddDataAccessLayer();
			services.AddAutoMapper(typeof(AutoMapperProfile));
			services.AddSingleton<ICurrencyService, CurrencyService>();
			services.AddSingleton<ICurrencyManager, CurrencyManager>();
			services.AddSingleton<IRateService, RateService>();
			services.AddSingleton<IRateManager, RateManager>();
			services.AddSingleton<IFundService, FundService>();
			services.AddSingleton<IFundManager, FundManager>();
			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IUserManager, UserManager>();
			services.AddSingleton<IUserRoleService, UserRoleService>();
			services.AddSingleton<IUserRoleManager, UserRoleManager>();
			services.AddSingleton<IContactService, ContactService>();
			services.AddSingleton<IContactManager, ContactManager>();
			services.AddSingleton<ITransactionService, TransactionService>();
			services.AddSingleton<ITransactionManager, TransactionManager>();
			services.AddSingleton<IReservationService, ReservationService>();
			services.AddSingleton<IReservationManager, ReservationManager>();
		}
	}
}
