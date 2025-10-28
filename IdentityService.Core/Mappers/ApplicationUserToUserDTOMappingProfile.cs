using AutoMapper;
using IdentityService.Core.DTO;
using IdentityService.Core.Entities;

namespace IdentityService.Core.Mappers
{
    public class ApplicationUserToUserDTOMappingProfile:Profile
    {
        public ApplicationUserToUserDTOMappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
