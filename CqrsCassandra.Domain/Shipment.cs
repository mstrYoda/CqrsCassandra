using System;

namespace CqrsCassandra.Domain
{
    public class Shipment
    {
        public long Id { get; private set; }
        public Person Sender { get; private set; }
        public Person Recipient { get; private set; }
        public CargoProvider CargoProvider { get; private set; }
        public int OrderId { get; private set; }
        public int TypeId { get; private set; }
        public int StatusId { get; private set; }
        public string StatusDescription { get; private set; }
        public string CargoLink { get; private set; }
        public string TrackingNumber { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public bool IsDeleted { get; private set; }

        public Shipment(
            Person sender, Person recipient, 
            CargoProvider cargoProvider, 
            int orderId)
        {
            Id = new Random().Next(1,10000);
            Sender = sender;
            Recipient = recipient;
            CargoProvider = cargoProvider;
            OrderId = orderId;
            TypeId = 1;
            StatusId = 1;
            StatusDescription = "New";
            CargoLink = "link";
            TrackingNumber = Guid.NewGuid().ToString();
            IsDeleted = false;
            CreatedOn = DateTime.Now;
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }

        public void ChangeCargoProvider(CargoProvider cargoProvider)
        {
            this.CargoProvider = cargoProvider;
        }

        public void ChangeCargoLink(string cargoLink)
        {
            this.CargoLink = cargoLink;
        }
    }
}
