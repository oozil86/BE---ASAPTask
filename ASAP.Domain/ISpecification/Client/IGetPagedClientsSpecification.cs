using ASAP.Domain.Contract;
using ASAP.Domain.Contracts;

namespace ASAP.Domain.ISpecification.Client
{
    public interface IGetPagedClientsSpecification : IAsyncSpecification<PagedEntity<Entities.Client>>
    {
        public PagationFilter Filter { get; set; }
    }
}
