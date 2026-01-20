using AutoMapper;
using DTO;
using Entities.Models;

namespace MyCAServer
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<UserSignupDTO, TUser>()
                .ForMember(dest => dest.IdCountry, opt => opt.MapFrom(src => src.IdCountry))
                .ForMember(dest => dest.IdBillingCountry, opt => opt.MapFrom(src => src.IdBillingCountry))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.BillingZipcode, opt => opt.MapFrom(src => src.BillingZipCode))
                .ForMember(dest => dest.StateRegion, opt => opt.MapFrom(src => src.stateRegion))
                .ForMember(dest => dest.BillingStateRegion, opt => opt.MapFrom(src => src.BillingstateRegion))
                .ForMember(dest => dest.HowHearAboutUs, opt => opt.MapFrom(src => src.HowHearAboutUs))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerName))
                .ForMember(dest => dest.CompanyOfficialId, opt => opt.MapFrom(src => src.CompanyOfficialId))
                .ReverseMap();
            CreateMap<TUser, ClientUserDTO>().ReverseMap();
        }
    }
}
