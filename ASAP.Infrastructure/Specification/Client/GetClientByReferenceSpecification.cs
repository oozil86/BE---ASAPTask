using ASAP.Domain.Contracts;
using ASAP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ASAP.Domain.ISpecification.Client;

namespace ASAP.Infrastructure.Specification.Client
{
    public class GetClientByReferenceSpecification : EFSpecification, IGetClientByReferenceSpecification, ScopedInjectable
    {
        public Guid ClientReference { set; get; }
        public GetClientByReferenceSpecification(ASAPContext context) : base(context)
        {

        }

        public async Task<Domain.Entities.Client?> Query(CancellationToken cancellationToken)
        {
            return await Context
                .Set<Domain.Entities.Client>()
                .FirstOrDefaultAsync(c =>c.Reference== ClientReference, cancellationToken: cancellationToken);
        }
    }
}
