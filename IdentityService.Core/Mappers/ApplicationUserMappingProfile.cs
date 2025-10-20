using AutoMapper;
using IdentityService.Core.DTO;
using IdentityService.Core.Entities;

namespace IdentityService.Core.Mappers
{
    public class ApplicationUserMappingProfile:Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, AuthResponse>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Success, opt => opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }

    }
}
