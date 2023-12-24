using AutoMapper;
using MediatR;
using ASAP.Domain.Model.Client;
using ASAP.Domain.ISpecification.Client;

namespace ASAP.ApplicationService.Features.Client
{

    public record GetClientsQuery : IRequest<List<ClientModel>>;
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientModel>>
    {
        private readonly IGetClientsSpecification getclientsspecification;
        private readonly IMapper mapper;
    
        public GetClientsQueryHandler(IGetClientsSpecification getclientsspecification,
            IMapper mapper

            )
        {
            this.getclientsspecification = getclientsspecification;
            this.mapper = mapper;
        }

        public async Task<List<ClientModel>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await getclientsspecification.Query(cancellationToken);
            return mapper.Map<List<ClientModel>>(clients);
        }
    }

}
