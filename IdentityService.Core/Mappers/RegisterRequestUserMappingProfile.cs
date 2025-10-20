using AutoMapper;
using IdentityService.Core.DTO;
using IdentityService.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class RegisterRequestUserMappingProfile : Profile
    {
        public RegisterRequestUserMappingProfile()
        {
            CreateMap<RegisterRequest, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
