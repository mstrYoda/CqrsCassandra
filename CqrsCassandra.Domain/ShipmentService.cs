using System.Threading.Tasks;

namespace CqrsCassandra.Domain
{
    public class ShipmentService
    {
        private readonly IShipmentCommandRepository _shipmentCommandRepository;

        public ShipmentService(IShipmentCommandRepository shipmentCreateRepository)
        {
            _shipmentCommandRepository = shipmentCreateRepository;
        }

        public Task CreateShipmentAsync(Shipment shipment)
        {
            return _shipmentCommandRepository.SaveAsync(shipment);
        }
    }
}