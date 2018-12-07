using System.Threading;
using System.Threading.Tasks;
using CqrsCassandra.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsCassandra.Application.Controllers
{
    [Route("api/shipments")]
    public class ShipmentController : Controller
    {
        private readonly IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateShipmentCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
