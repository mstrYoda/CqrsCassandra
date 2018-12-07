using MediatR;

namespace CqrsCassandra.Application.Commands
{
    public class CreateShipmentCommand : IRequest<long>
    {
        public int OrderId { get; set; }
    }
}