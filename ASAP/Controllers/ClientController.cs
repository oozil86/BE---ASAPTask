using ASAP.ApplicationService.Features.Client;
using ASAP.Domain.Contracts;
using ASAP.Domain.Model.Client;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ASAP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("TaskCors")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private readonly IMediator mediator;

        public ClientController(ILogger<ClientController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(List<ClientModel>))]
        public async Task<IActionResult> Get()
        => Ok(await mediator.Send(new GetClientsQuery()));

        [HttpGet("GetPagedClients")]
        [Produces("application/json", Type = typeof(PagedEntity<ClientModel>))]
        public async Task<IActionResult> Get([FromQuery] PagationFilter filter)
        => Ok(await mediator.Send(new GetPagedClientsQuery(filter)));


        [HttpGet("{reference}")]
        [Produces("application/json", Type = typeof(ClientModel))]
        public async Task<IActionResult> Get([FromRoute] Guid reference)
        => Ok(await mediator.Send(new GetClientQuery(reference)));

        [HttpDelete("{reference}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> Delete([FromRoute] Guid reference)
        => Ok(await mediator.Send(new DeleteClientCommand(reference)));

        [HttpPost]
        [Produces("application/json", Type = typeof(Guid))]
        public async Task<IActionResult> Post(SaveClientModel Client)
          => Ok(await mediator.Send(new SaveClientCommand(Client)));
   
        [HttpPut]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> Put(EditClientModel Client)
          => Ok(await mediator.Send(new EditClientCommand(Client)));

    }
}
