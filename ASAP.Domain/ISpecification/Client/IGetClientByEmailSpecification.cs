using ASAP.Domain.Contract;

namespace ASAP.Domain.ISpecification.Client
{
    public interface IGetClientByEmailSpecification : IAsyncSpecification<Entities.Client?>
    {
        public string ClientEmail { set; get; }
    }
}
