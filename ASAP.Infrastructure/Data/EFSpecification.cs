using Microsoft.EntityFrameworkCore;

namespace ASAP.Domain.Contracts
{
    public class EFSpecification
    {
        public DbContext Context { get; private set; }

        public EFSpecification(DbContext context)
        {
            Context = context;
        }
    }
}
