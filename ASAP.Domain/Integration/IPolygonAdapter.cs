using ASAP.Domain.Model.Integration;

namespace ASAP.Domain.Integration
{
    public interface IPolygonAdapter
    {
        public Task<PolygonResponseModel> GetUpdatedProductsInfo();
    }
}
