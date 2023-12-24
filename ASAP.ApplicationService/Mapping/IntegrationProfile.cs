using ASAP.Domain.Entities;
using ASAP.Domain.Model.Integration;
using AutoMapper;

namespace ASAP.ApplicationService.Mapping
{
    public class IntegrationProfile : Profile
    {
        public IntegrationProfile() 
        {
            CreateMap<PolygonResponseResultModel, PolygonResponseResult>();
            CreateMap<PolygonResponseModel, PolygonResponse>();
        }
    }
}
