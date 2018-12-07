using System.Threading;
using System.Threading.Tasks;
using CqrsCassandra.Domain;
using MediatR;

namespace CqrsCassandra.Application.Commands
{
    public class ShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, long>
    {
        private readonly ShipmentService _shipmentDomainService;

        public ShipmentCommandHandler(ShipmentService shipmentDomainService)
        {
            _shipmentDomainService = shipmentDomainService;
        }
        
        public async Task<long> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            Shipment shipment = new Shipment(null, null, null, request.OrderId);
            
            await _shipmentDomainService.CreateShipmentAsync(shipment);

            return shipment.Id;
        }
    }
}