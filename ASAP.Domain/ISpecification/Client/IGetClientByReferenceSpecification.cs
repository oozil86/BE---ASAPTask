using ASAP.Domain.Contract;

namespace ASAP.Domain.ISpecification.Client
{
    public interface IGetClientByReferenceSpecification : IAsyncSpecification<Entities.Client?>
    {
        public Guid ClientReference { set; get; }
    }
}
