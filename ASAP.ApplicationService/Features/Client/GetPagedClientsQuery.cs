using AutoMapper;
using MediatR;
using ASAP.Domain.Model.Client;
using ASAP.Domain.ISpecification.Client;
using ASAP.Domain.Contracts;

namespace ASAP.ApplicationService.Features.Client
{

    public record GetPagedClientsQuery(PagationFilter Filter) : IRequest<PagedEntity<ClientModel>>;
    public class GetPagedClientsQueryHandler : IRequestHandler<GetPagedClientsQuery, PagedEntity<ClientModel>>
    {
        private readonly IGetPagedClientsSpecification getpagedclientsspecification;
        private readonly IMapper mapper;
        public GetPagedClientsQueryHandler(IGetPagedClientsSpecification getpagedclientsspecification, IMapper mapper)
        {
            this.getpagedclientsspecification = getpagedclientsspecification;
            this.mapper = mapper;
        }

        public async Task<PagedEntity<ClientModel>> Handle(GetPagedClientsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                getpagedclientsspecification.Filter = request.Filter;
                var clients = await getpagedclientsspecification.Query(cancellationToken);
                var Mappedclients = mapper.Map<List<ClientModel>>(clients.Items);

                return new PagedEntity<ClientModel>(Mappedclients, clients.TotalCount);
            }
            catch (Exception ex) 
            {
                throw;
            }

        }
    }

}
