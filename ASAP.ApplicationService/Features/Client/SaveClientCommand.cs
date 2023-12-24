using ASAP.Domain.Data;
using ASAP.Domain.ISpecification.Client;
using ASAP.Domain.Model.Client;
using AutoMapper;
using MediatR;

namespace ASAP.ApplicationService.Features.Client
{

    public record SaveClientCommand(SaveClientModel Client) : IRequest<Guid>;
    public class SaveClientCommandHandler : IRequestHandler<SaveClientCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.Client, Guid> genericRepository;
        private readonly IMapper mapper;
        private readonly IASAPUnitOfWork ASAPUnitOfWork;
        private readonly IGetClientByEmailSpecification getclientbyemailspecification;
        

        public SaveClientCommandHandler(
            IGenericRepository<Domain.Entities.Client, Guid> genericRepository,
            IMapper mapper,
            IASAPUnitOfWork ASAPUnitOfWork,
            IGetClientByEmailSpecification getclientbyemailspecification
            )
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
            this.ASAPUnitOfWork = ASAPUnitOfWork;
            this.getclientbyemailspecification = getclientbyemailspecification; 
         }

        public async Task<Guid> Handle(SaveClientCommand request, CancellationToken cancellationToken)
        {
            getclientbyemailspecification.ClientEmail = request.Client.Email;
            var ExistedClient = await getclientbyemailspecification.Query(cancellationToken) ;

            if (ExistedClient is not null)
                throw new Exception("This Email Already Exists.");

            var Course = mapper.Map<Domain.Entities.Client>(request.Client);
            await genericRepository.AddAsync(Course);
            await ASAPUnitOfWork.SaveAsync(cancellationToken);
            return Course.Reference;

        }
    }
}
