using ASAP.Domain.Contract;

namespace ASAP.Domain.ISpecification.Client
{
    public interface IGetClientByEmailAndReferenceSpecification : IAsyncSpecification<Entities.Client?>
    {
        public string ClientEmail { set; get; }
        public Guid ClientReference { set; get; }
    }
}
