using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using CqrsCassandra.Domain;

namespace CqrsCassandra.Infrastructure
{
    public class ShipmentCommandRepository : IShipmentCommandRepository
    {
        private readonly ISession _session;

        public ShipmentCommandRepository(ISession session)
        {
            _session = session;
        }
        
        public Task SaveAsync(Shipment shipment)
        {
            return Mapper().InsertAsync(shipment);
        }

        public void Update(Shipment shipment)
        {
            
        }

        public void Delete(long id)
        {
            
        }

        private Mapper Mapper()
        {
            return new Mapper(_session);
        }
    }
}
