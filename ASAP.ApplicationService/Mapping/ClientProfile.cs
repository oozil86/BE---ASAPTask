using ASAP.Domain.Entities;
using ASAP.Domain.Model.Client;
using AutoMapper;

namespace ASAP.ApplicationService.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<Client, ClientModel>()
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
             .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
             .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference));

            CreateMap<SaveClientModel, Client>();


        }
    }
}
