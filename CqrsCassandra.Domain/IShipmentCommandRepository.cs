using System.Threading.Tasks;

namespace CqrsCassandra.Domain
{
    public interface IShipmentCommandRepository
    {
        Task SaveAsync(Shipment shipment);
        void Update(Shipment shipment);
        void Delete(long shipmentId);
    }
}