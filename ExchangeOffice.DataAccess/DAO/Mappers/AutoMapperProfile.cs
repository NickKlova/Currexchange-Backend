using AutoMapper;

namespace ExchangeOffice.DataAccess.DAO.Mappers {
	public class AutoMapperProfile : Profile {
		public AutoMapperProfile() {
			CreateContactMapper();
		}

		private void CreateContactMapper() {
			CreateMap<Contact, Contact>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
				.ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
		}
	}
}
