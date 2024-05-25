using AutoMapper;

namespace ExchangeOffice.DataAccess.DAO.Mappers {
	public class AutoMapperProfile : Profile {
		public AutoMapperProfile() {
			CreateContactMapper();
			CreateCurrencyMapper();
			CreateFundMapper();
			CreateRateMapper();
			CreateReservationMapper();
			CreateTransactionMapper();
		}

		private void CreateContactMapper() {
			CreateMap<Contact, Contact>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
		private void CreateCurrencyMapper() {
			CreateMap<Currency, Currency>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
		private void CreateFundMapper() {
			CreateMap<Fund, Fund>()
				.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
		private void CreateRateMapper() {
			CreateMap<Rate, Rate>()
				.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
		private void CreateReservationMapper() {
			CreateMap<Reservation, Reservation>()
				.ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
				.ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
		private void CreateTransactionMapper() {
			CreateMap<Transaction, Transaction>()
				.ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
				.ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
	}
}
