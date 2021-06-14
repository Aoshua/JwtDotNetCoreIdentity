using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtDotNetCoreIdentity.Models
{
    [NotMapped]
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
