using AutoMapper;
using ExchangeOffice.DataAccess.DAO;

namespace ExchangeOffice.Application.DTO.Mappers {
	public class AutoMapperProfile : Profile {
		public AutoMapperProfile() {
			CreateCurrencyMappers();
			CreateContactMappers();
			CreateRateMappers();
			CreateFundMappers();
			CreateUserRoleMappers();
			CreateUserMappers();
			CreateTransactionMappers();
			CreateReservationMappers();
		}

		private void CreateCurrencyMappers() {
			CreateMap<IEnumerable<Currency>, IEnumerable<CurrencyDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<CurrencyDto>(x)));

			CreateMap<Currency, CurrencyDto>();

			CreateMap<InsertCurrencyDto, Currency>();
		}

		private void CreateRateMappers() {
			CreateMap<IEnumerable<Rate>, IEnumerable<RateDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<RateDto>(x)));

			CreateMap<Rate, RateDto>()
				.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

			CreateMap<RateDto, InsertRateDto>();

			CreateMap<InsertRateDto, Rate>();
		}

		private void CreateFundMappers() {
			CreateMap<IEnumerable<Fund>, IEnumerable<FundDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<FundDto>(x)));

			CreateMap<FundDto, InsertFundDto>();

			CreateMap<Fund, FundDto>()
				.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

			CreateMap<InsertFundDto, Fund>();
		}

		private void CreateUserMappers() {
			CreateMap<User, UserDto>()
				.ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
				.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

			CreateMap<InsertUserDto, User>();
		}

		private void CreateUserRoleMappers() {
			CreateMap<IEnumerable<UserRole>, IEnumerable<UserRoleDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<UserRoleDto>(x)));

			CreateMap<UserRole, UserRoleDto>();
		}

		private void CreateContactMappers() {
			CreateMap<IEnumerable<Contact>, IEnumerable<ContactDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<ContactDto>(x)));

			CreateMap<InsertContactDto, Contact>();

			CreateMap<Contact, ContactDto>();
		}

		private void CreateTransactionMappers() {
			CreateMap<IEnumerable<Transaction>, IEnumerable<TransactionDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<TransactionDto>(x)));

			CreateMap<InsertTransactionDto, Transaction>();

			CreateMap<Transaction, TransactionDto>();
		}

		private void CreateReservationMappers() {
			CreateMap<IEnumerable<Reservation>, IEnumerable<ReservationDto>>()
				.ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<ReservationDto>(x)));

			CreateMap<InsertReservationDto, Reservation>();

			CreateMap<Reservation, ReservationDto>();
		}
	}
}
