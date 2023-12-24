using ASAP.Domain.Contracts;
using ASAP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ASAP.Domain.ISpecification.Client;

namespace ASAP.Infrastructure.Specification.Client
{
    public class GetClientByEmailSpecification : EFSpecification, IGetClientByEmailSpecification, ScopedInjectable
    {
        public string ClientEmail { set; get; }
        public GetClientByEmailSpecification(ASAPContext context) : base(context)
        {

        }

        public async Task<Domain.Entities.Client?> Query(CancellationToken cancellationToken)
        {
            return await Context
                .Set<Domain.Entities.Client>()
                .FirstOrDefaultAsync(c => c.Email == ClientEmail, cancellationToken: cancellationToken);
        }
    }
}
