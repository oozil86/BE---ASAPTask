using ASAP.Domain.Data;
using ASAP.Domain.ISpecification.Client;
using ASAP.Domain.Model.Client;
using MediatR;

namespace ASAP.ApplicationService.Features.Client
{
    public record EditClientCommand(EditClientModel Client) : IRequest<bool>;
    public class EditClientCommandHandler : IRequestHandler<EditClientCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.Client, Guid> genericRepository;
        private readonly IASAPUnitOfWork ASAPUnitOfWork;
        private readonly IGetClientByReferenceSpecification getclientbyreferencespecification;
        private readonly IGetClientByEmailAndReferenceSpecification getclientbyemailandreferencespecification;

        public EditClientCommandHandler(IGenericRepository<Domain.Entities.Client, Guid> genericRepository,
            IASAPUnitOfWork ASAPUnitOfWork,
             IGetClientByReferenceSpecification getclientbyreferencespecification,
             IGetClientByEmailAndReferenceSpecification getclientbyemailandreferencespecification
            )
        {
            this.genericRepository = genericRepository;
            this.ASAPUnitOfWork = ASAPUnitOfWork;
            this.getclientbyreferencespecification = getclientbyreferencespecification;
            this.getclientbyemailandreferencespecification = getclientbyemailandreferencespecification;
        }

        public async Task<bool> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            getclientbyreferencespecification.ClientReference = request.Client.Reference;
            var client = await getclientbyreferencespecification.Query(cancellationToken) ?? throw new Exception("This Coupon Not Found.");

            getclientbyemailandreferencespecification.ClientEmail = request.Client.Email;
            getclientbyemailandreferencespecification.ClientReference = request.Client.Reference;
            var ExistedClient = await getclientbyemailandreferencespecification.Query(cancellationToken);

            if (ExistedClient is not null)
                throw new Exception("This Email Already Exists.");

            client.Edit(request.Client.FirstName, request.Client.LastName, request.Client.Email, request.Client.PhoneNumber);
            genericRepository.Update(client);
            await ASAPUnitOfWork.SaveAsync(cancellationToken);

            return true;

        }
    }
}
