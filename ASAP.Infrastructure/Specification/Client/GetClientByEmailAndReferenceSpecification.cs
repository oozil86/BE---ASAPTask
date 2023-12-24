using ASAP.Domain.Contracts;
using ASAP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ASAP.Domain.ISpecification.Client;

namespace ASAP.Infrastructure.Specification.Client
{
    public class GetClientByEmailAndReferenceSpecification : EFSpecification, IGetClientByEmailAndReferenceSpecification, ScopedInjectable
    {
        public string ClientEmail { set; get; }
        public Guid ClientReference { set; get; }
        public GetClientByEmailAndReferenceSpecification(ASAPContext context) : base(context)
        {

        }

        public async Task<Domain.Entities.Client?> Query(CancellationToken cancellationToken)
        {
            return await Context
                .Set<Domain.Entities.Client>()
                .FirstOrDefaultAsync(c => c.Email == ClientEmail && c.Reference != ClientReference, cancellationToken: cancellationToken);
        }
    }
}
