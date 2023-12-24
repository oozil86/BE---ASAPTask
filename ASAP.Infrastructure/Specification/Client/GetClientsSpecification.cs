using ASAP.Domain.Contracts;
using ASAP.Domain.ISpecification.Client;
using ASAP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASAP.Infrastructure.Specification.Client
{
    internal class GetClientsSpecification : EFSpecification, IGetClientsSpecification, ScopedInjectable
    {
        public GetClientsSpecification(ASAPContext context) : base(context)
        {

        }

        public async Task<List<Domain.Entities.Client>> Query(CancellationToken cancellationToken)
        {
            return await Context
                .Set<Domain.Entities.Client>()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
