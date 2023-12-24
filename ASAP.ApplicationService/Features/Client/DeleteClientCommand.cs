using ASAP.Domain.Data;
using ASAP.Domain.ISpecification.Client;
using MediatR;

namespace ASAP.ApplicationService.Features.Client
{

    public record DeleteClientCommand(Guid ClientReference) : IRequest<bool>;
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly IGetClientByReferenceSpecification getclientbyreferencespecification;
        private readonly IASAPUnitOfWork ASAPUnitOfWork;
        public DeleteClientCommandHandler(IGetClientByReferenceSpecification getclientbyreferencespecification, IASAPUnitOfWork ASAPUnitOfWork)
        {
            this.getclientbyreferencespecification = getclientbyreferencespecification;
            this.ASAPUnitOfWork = ASAPUnitOfWork;
        }

        public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            getclientbyreferencespecification.ClientReference = request.ClientReference;
            var Course = await getclientbyreferencespecification.Query(cancellationToken) ?? throw new Exception("Client Not Found.");
            Course.SoftDelete();
            await ASAPUnitOfWork.SaveAsync(cancellationToken);

            return true;

        }
    }

}
