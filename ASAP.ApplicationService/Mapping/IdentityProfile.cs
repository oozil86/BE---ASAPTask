using AutoMapper;
using ASAP.Domain.Entities;
using ASAP.Domain.Model.Identity;

namespace ASAP.ApplicationService.Mapping
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile() 
        {
            CreateMap<AppUserModel, AppUser>();

         }
    }
}
