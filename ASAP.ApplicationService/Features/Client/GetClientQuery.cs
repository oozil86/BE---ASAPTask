using AutoMapper;
using MediatR;
using ASAP.Domain.Model.Client;
using ASAP.Domain.ISpecification.Client;

namespace ASAP.ApplicationService.Features.Client
{

    public record GetClientQuery(Guid Reference) : IRequest<ClientModel>;
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientModel>
    {
        private readonly IGetClientByReferenceSpecification getclientbyreferencespecification;
        private readonly IMapper mapper;
        public GetClientQueryHandler(IGetClientByReferenceSpecification getclientbyreferencespecification, IMapper mapper)
        {
            this.getclientbyreferencespecification = getclientbyreferencespecification;
            this.mapper = mapper;
        }

        public async Task<ClientModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            getclientbyreferencespecification.ClientReference = request.Reference;
            var clients = await getclientbyreferencespecification.Query(cancellationToken);
            return mapper.Map<ClientModel>(clients);

        }
    }

}
