using ASAP.Domain.Contracts;
using ASAP.Domain.ISpecification.Client;
using ASAP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASAP.Infrastructure.Specification.Client
{
    public class GetPagedClientsSpecification : EFSpecification, IGetPagedClientsSpecification, ScopedInjectable
    {
        public PagationFilter Filter { get; set; }
        public GetPagedClientsSpecification(ASAPContext context) : base(context)
        {

        }

        public async Task<PagedEntity<Domain.Entities.Client>> Query(CancellationToken cancellationToken)
        {
            var clients = new List<Domain.Entities.Client>();
            var offset = (Filter.PageIndex - 1) * Filter.PageSize;
            IQueryable<Domain.Entities.Client> Query= Context
                    .Set<Domain.Entities.Client>()
                    .Skip(offset).Take(Filter.PageSize);

            if (Filter.SortField == "FirstName")
                Query = Filter.SortOrder == 1 ? Query.OrderBy(c => c.FirstName)
                    : Query.OrderByDescending(c => c.FirstName);
            else if (Filter.SortField == "LastName")
                Query = Filter.SortOrder == 1 ? Query.OrderBy(c => c.LastName)
                  : Query.OrderByDescending(c => c.LastName);
            else if (Filter.SortField == "Email")
                Query = Filter.SortOrder == 1 ? Query.OrderBy(c => c.Email)
                 : Query.OrderByDescending(c => c.Email);
            else if (Filter.SortField == "PhoneNumber")
                Query = Filter.SortOrder == 1 ? Query.OrderBy(c => c.PhoneNumber)
                 : Query.OrderByDescending(c => c.PhoneNumber);
           
            clients = await Query.ToListAsync();
            var count= await Query.CountAsync();
            return new PagedEntity<Domain.Entities.Client>(clients, count);
        }
    }
}

